namespace Aplicacion.Companias
{
    using Aplicacion.ManejadorError;
    using AutoMapper;
    using Dominio;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Persistencia;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    public class Consulta
    {
        public class ListaComanias:IRequest<List<CompaniaDto>>
        {

        }
        public class Manejador : IRequestHandler<ListaComanias, List<CompaniaDto>>
        {
            private readonly WeeCompanyContext _context;
            private readonly IMapper _mapper;
            public Manejador(WeeCompanyContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<CompaniaDto>> Handle(ListaComanias request, CancellationToken cancellationToken)
            {
                var resultado = await _context.Compania.ToListAsync();
                if (resultado == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se encontro registros de compañias" });
                }
                var resultadoDTO = _mapper.Map<List<Compania>, List<CompaniaDto>>(resultado);
                return resultadoDTO;
            }
        }
    }
}
