using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonasAutos.Dtos;
using PersonasAutos.Models;
using PersonasAutos.Servicio;

namespace PersonasAutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private AutoService _service = new AutoService();
        [HttpGet("Listar")]
        public List<Auto> Listar()
        {
            return _service.MostrarAutos();
        }

        [HttpPost("Guardar")]
        public Respuesta Guardar([FromBody] Auto auto)
        {
            return _service.Guardar(auto);
        }

        [HttpPost("Editar")]
        public Respuesta Editar([FromBody] Auto auto)
        {
            return _service.Editar(auto);
        }

        [HttpGet("Buscar")]
        public Auto Buscar(string matricula)
        {
            return _service.Buscar(matricula);
        }

        [HttpPost("Eliminar")]
        public Respuesta Eliminar([FromBody] Auto auto)
        {
            return _service.Eliminar(auto);
        }
    }
}
