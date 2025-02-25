using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PersonasAutos.Dtos;
using PersonasAutos.Models;
using PersonasAutos.Servicio;

namespace PersonasAutos.Controllers
{
    [Route("api/persona")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private PersonaService _service = new PersonaService();
        [HttpGet("Listar")]
        public List<Persona> Listar()
        {
            return _service.MostrarPersonas();
        }

        [HttpPost("Guardar")]
        public Respuesta Guardar([FromBody] Persona persona)
        {
            return _service.Guardar(persona);
        }

        [HttpPost("Editar")]
        public Respuesta Editar([FromBody] Persona persona)
        {
            return _service.Editar(persona);
        }

        [HttpGet("Buscar")]
        public Persona Buscar(string curp)
        {
            return _service.Buscar(curp);
        }

        [HttpPost("Eliminar")]
        public Respuesta Eliminar([FromBody] Persona persona)
        {
            return _service.Eliminar(persona);
        }
    }
}
