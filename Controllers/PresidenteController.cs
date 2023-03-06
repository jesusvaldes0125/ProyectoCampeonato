using CampeonatoFutbol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoFutbol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresidenteController : ControllerBase
    {
        private readonly DbproyectoContext _dbcontext;
        public PresidenteController(DbproyectoContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Lista()
        {
            List<Presidente> lista = await _dbcontext.Presidentes.OrderByDescending(c => c.Id).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Presidente request)
        {
            await _dbcontext.Presidentes.AddAsync(request);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Presidente request)
        {
            _dbcontext.Presidentes.Update(request);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Presidente presidente = _dbcontext.Presidentes.Find(id);
            _dbcontext.Presidentes.Remove(presidente);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
