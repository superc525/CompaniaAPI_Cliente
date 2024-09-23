namespace Aplicacion.Companias
{
    using AutoMapper;
    using Dominio;
    using FluentValidation;
    using MediatR;
    using Persistencia;
    using System;
    using System.Threading.Tasks;

    public class Nuevo
    {
        public class Ejecuta:IRequest 
        {
            public string NombreCompania { get; set; }
            public string NombrePersonaContacto { get; set; }
            public string CorreoElectronico { get; set; }
            public string Telefono { get; set; }
        }
        public class EjecutarValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutarValidacion()
            {
                RuleFor(x => x.NombreCompania).NotEmpty()
                    .WithMessage("El Nombre de la compalia no puede ser vacia");
                RuleFor(x => x.NombrePersonaContacto).NotEmpty()
                     .WithMessage("El Nombre de la compalia no puede ser vacia");
                RuleFor(x => x.CorreoElectronico).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty()
                    .Must(x => x.Length == 10).WithMessage("El número de telefono debe ser de 10 digitos");
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly WeeCompanyContext _context;
            public Manejador(WeeCompanyContext context, IMapper mapper)
            {
                _context = context;
            }
            public async Task Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var compania = new Compania
                {
                    NombreCompania = request.NombreCompania,
                    NombrePersonaContacto = request.NombrePersonaContacto,
                    CorreoElectronico = request.CorreoElectronico,
                    Telefono = request.Telefono
                };
                _context.Compania.Add(compania);
                var respuesta = await _context.SaveChangesAsync();
                if(respuesta == 0)
                {
                    throw new Exception("No se pudo agregar el nuevo registro");
                }
                
            }
        }
    }
}
