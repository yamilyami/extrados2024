using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

namespace TPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JuezController : ControllerBase
    {
        // Clase Juez que coincide con la estructura de tu tabla
        public class Juez
        {
            public int IdJuez { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Certificacion { get; set; } // Nivel o tipo de certificaci�n del juez
        }

        [HttpPost]
        public IActionResult CreateJuez([FromBody] Juez juez)
        {
            // Simulaci�n de creaci�n del juez
            return CreatedAtAction(nameof(GetJuezById), new { id = juez.IdJuez }, juez);
        }

        [HttpGet]
        public IActionResult GetJueces()
        {
            // Simulaci�n de obtener jueces
            var jueces = new List<Juez>
            {
                new Juez { IdJuez = 1, Nombre = "Juan", Apellido = "P�rez", Certificacion = "Nivel 1" },
                new Juez { IdJuez = 2, Nombre = "Mar�a", Apellido = "G�mez", Certificacion = "Nivel 2" }
            };

            return Ok(jueces);
        }

        [HttpGet("{id}")]
        public IActionResult GetJuezById(int id)
        {
            // Simulaci�n de obtener un juez por ID
            var juez = new Juez { IdJuez = id, Nombre = "Juan", Apellido = "P�rez", Certificacion = "Nivel 1" };

            if (juez == null)
            {
                return NotFound();
            }

            return Ok(juez);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJuez(int id, [FromBody] Juez juez)
        {
            if (id != juez.IdJuez)
            {
                return BadRequest("El ID del juez no coincide.");
            }

            // Simulaci�n de actualizaci�n del juez
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJuez(int id)
        {
            // Simulaci�n de eliminaci�n del juez
            return NoContent();
        }
    }
}
