using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

namespace TPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizadorController : ControllerBase
    {
        // Clase Organizador que coincide con la estructura de tu tabla
        public class Organizador
        {
            public int IdOrganizador { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Empresa { get; set; } // Empresa o institución asociada
        }

        [HttpPost]
        public IActionResult CreateOrganizador([FromBody] Organizador organizador)
        {
            // Simulación de creación del organizador
            return CreatedAtAction(nameof(GetOrganizadorById), new { id = organizador.IdOrganizador }, organizador);
        }

        [HttpGet]
        public IActionResult GetOrganizadores()
        {
            // Simulación de obtener organizadores
            var organizadores = new List<Organizador>
            {
                new Organizador { IdOrganizador = 1, Nombre = "Carlos", Apellido = "López", Empresa = "Torneos SA" },
                new Organizador { IdOrganizador = 2, Nombre = "Ana", Apellido = "Martínez", Empresa = "Eventos SL" }
            };

            return Ok(organizadores);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrganizadorById(int id)
        {
            // Simulación de obtener un organizador por ID
            var organizador = new Organizador { IdOrganizador = id, Nombre = "Carlos", Apellido = "López", Empresa = "Torneos SA" };

            if (organizador == null)
            {
                return NotFound();
            }

            return Ok(organizador);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrganizador(int id, [FromBody] Organizador organizador)
        {
            if (id != organizador.IdOrganizador)
            {
                return BadRequest("El ID del organizador no coincide.");
            }

            // Simulación de actualización del organizador
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrganizador(int id)
        {
            // Simulación de eliminación del organizador
            return NoContent();
        }
    }
}
