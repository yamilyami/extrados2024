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
            public string Empresa { get; set; } // Empresa o instituci�n asociada
        }

        [HttpPost]
        public IActionResult CreateOrganizador([FromBody] Organizador organizador)
        {
            // Simulaci�n de creaci�n del organizador
            return CreatedAtAction(nameof(GetOrganizadorById), new { id = organizador.IdOrganizador }, organizador);
        }

        [HttpGet]
        public IActionResult GetOrganizadores()
        {
            // Simulaci�n de obtener organizadores
            var organizadores = new List<Organizador>
            {
                new Organizador { IdOrganizador = 1, Nombre = "Carlos", Apellido = "L�pez", Empresa = "Torneos SA" },
                new Organizador { IdOrganizador = 2, Nombre = "Ana", Apellido = "Mart�nez", Empresa = "Eventos SL" }
            };

            return Ok(organizadores);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrganizadorById(int id)
        {
            // Simulaci�n de obtener un organizador por ID
            var organizador = new Organizador { IdOrganizador = id, Nombre = "Carlos", Apellido = "L�pez", Empresa = "Torneos SA" };

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

            // Simulaci�n de actualizaci�n del organizador
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrganizador(int id)
        {
            // Simulaci�n de eliminaci�n del organizador
            return NoContent();
        }
    }
}
