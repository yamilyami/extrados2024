using Microsoft.AspNetCore.Mvc;

namespace TPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TorneoController : ControllerBase
    {
        // Clase Torneo que coincide con la estructura de tu tabla
        public class Torneo
        {
            public int IdTorneo { get; set; }
            public string Nombre { get; set; }
            public string Ubicacion { get; set; }
            public DateTime Fecha { get; set; }
            public int NumeroParticipantes { get; set; }
        }

        [HttpPost]
        public IActionResult CreateTorneo([FromBody] Torneo torneo)
        {
            // Simulaci�n de creaci�n del torneo
            return CreatedAtAction(nameof(GetTorneoById), new { id = torneo.IdTorneo }, torneo);
        }

        [HttpGet]
        public IActionResult GetTorneos()
        {
            // Simulaci�n de obtener torneos de la base de datos
            var torneos = new List<Torneo>
            {
                new Torneo
                {
                    IdTorneo = 1,
                    Nombre = "Copa Am�rica",
                    Ubicacion = "Argentina",
                    Fecha = new DateTime(2025, 1, 20),
                    NumeroParticipantes = 12
                },
                new Torneo
                {
                    IdTorneo = 2,
                    Nombre = "Liga Nacional",
                    Ubicacion = "Brasil",
                    Fecha = new DateTime(2025, 3, 15),
                    NumeroParticipantes = 10
                }
            };

            return Ok(torneos);
        }

        [HttpGet("{id}")]
        public IActionResult GetTorneoById(int id)
        {
            // Simulaci�n de obtener un torneo por ID
            var torneo = new Torneo
            {
                IdTorneo = id,
                Nombre = "Copa Am�rica",
                Ubicacion = "Argentina",
                Fecha = new DateTime(2025, 1, 20),
                NumeroParticipantes = 12
            };

            if (torneo == null)
            {
                return NotFound();
            }

            return Ok(torneo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTorneo(int id, [FromBody] Torneo torneo)
        {
            if (id != torneo.IdTorneo)
            {
                return BadRequest("El ID del torneo no coincide.");
            }

            // Simulaci�n de actualizaci�n del torneo

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTorneo(int id)
        {
            // Simulaci�n de eliminaci�n del torneo

            return NoContent();
        }
    }
}

