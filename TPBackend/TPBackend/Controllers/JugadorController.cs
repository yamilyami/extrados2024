using Microsoft.AspNetCore.Mvc;

//using System.Collections.Generic;

namespace TPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JugadorController : ControllerBase
    {
        // Clase Jugador que coincide con la estructura de tu tabla
        public class Jugador
        {
            public int IdJugador { get; set; }
            public string Alias { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int TorneosGanados { get; set; }
        }

        [HttpPost]
        public IActionResult CreateJugador([FromBody] Jugador jugador)
        {
            // Simulaci�n de creaci�n del jugador
            return CreatedAtAction(nameof(GetJugadorById), new { id = jugador.IdJugador }, jugador);
        }

        [HttpGet]
        public IActionResult GetJugadores()
        {
            // Simulaci�n de obtener jugadores
            var jugadores = new List<Jugador>
            {
                new Jugador { IdJugador = 1, Alias = "ElMaestro", Nombre = "Pedro", Apellido = "Ruiz", TorneosGanados = 3 },
                new Jugador { IdJugador = 2, Alias = "ChicaPro", Nombre = "Sof�a", Apellido = "Mart�nez", TorneosGanados = 5 }
            };

            return Ok(jugadores);
        }

        [HttpGet("{id}")]
        public IActionResult GetJugadorById(int id)
        {
            // Simulaci�n de obtener un jugador por ID
            var jugador = new Jugador { IdJugador = id, Alias = "ElMaestro", Nombre = "Pedro", Apellido = "Ruiz", TorneosGanados = 3 };

            if (jugador == null)
            {
                return NotFound();
            }

            return Ok(jugador);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJugador(int id, [FromBody] Jugador jugador)
        {
            if (id != jugador.IdJugador)
            {
                return BadRequest("El ID del jugador no coincide.");
            }

            // Simulaci�n de actualizaci�n del jugador
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJugador(int id)
        {
            // Simulaci�n de eliminaci�n del jugador
            return NoContent();
        }
    }
}
