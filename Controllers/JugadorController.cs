using CampeonatoFutbol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoFutbol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        private readonly DbproyectoContext _dbcontext;
        public JugadorController(DbproyectoContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Lista()
        {
            List<Jugador> lista = await _dbcontext.Jugadors.OrderByDescending(c => c.Id).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Jugador request)
        {
            await _dbcontext.Jugadors.AddAsync(request);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Jugador request)
        {
            _dbcontext.Jugadors.Update(request);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Jugador jugador = _dbcontext.Jugadors.Find(id);
            _dbcontext.Jugadors.Remove(jugador);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
