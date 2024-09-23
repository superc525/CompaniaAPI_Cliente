using Aplicacion.Companias;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Runtime.CompilerServices;

namespace WeeCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniasController : ControladorBase
    {
        
        [HttpGet]
        public async Task<ActionResult<List<CompaniaDto>>> Get()
        {
            return  await Mediator.Send(new Consulta.ListaComanias());
        }
        [HttpPost]
        public async Task Nuevo(Nuevo.Ejecuta datos)
        {
            await Mediator.Send(datos);
        }
    }
}
