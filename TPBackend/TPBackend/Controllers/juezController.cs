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
            public string Certificacion { get; set; } // Nivel o tipo de certificación del juez
        }

        [HttpPost]
        public IActionResult CreateJuez([FromBody] Juez juez)
        {
            // Simulación de creación del juez
            return CreatedAtAction(nameof(GetJuezById), new { id = juez.IdJuez }, juez);
        }

        [HttpGet]
        public IActionResult GetJueces()
        {
            // Simulación de obtener jueces
            var jueces = new List<Juez>
            {
                new Juez { IdJuez = 1, Nombre = "Juan", Apellido = "Pérez", Certificacion = "Nivel 1" },
                new Juez { IdJuez = 2, Nombre = "María", Apellido = "Gómez", Certificacion = "Nivel 2" }
            };

            return Ok(jueces);
        }

        [HttpGet("{id}")]
        public IActionResult GetJuezById(int id)
        {
            // Simulación de obtener un juez por ID
            var juez = new Juez { IdJuez = id, Nombre = "Juan", Apellido = "Pérez", Certificacion = "Nivel 1" };

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

            // Simulación de actualización del juez
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJuez(int id)
        {
            // Simulación de eliminación del juez
            return NoContent();
        }
    }
}
