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
            // Simulación de creación del jugador
            return CreatedAtAction(nameof(GetJugadorById), new { id = jugador.IdJugador }, jugador);
        }

        [HttpGet]
        public IActionResult GetJugadores()
        {
            // Simulación de obtener jugadores
            var jugadores = new List<Jugador>
            {
                new Jugador { IdJugador = 1, Alias = "ElMaestro", Nombre = "Pedro", Apellido = "Ruiz", TorneosGanados = 3 },
                new Jugador { IdJugador = 2, Alias = "ChicaPro", Nombre = "Sofía", Apellido = "Martínez", TorneosGanados = 5 }
            };

            return Ok(jugadores);
        }

        [HttpGet("{id}")]
        public IActionResult GetJugadorById(int id)
        {
            // Simulación de obtener un jugador por ID
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

            // Simulación de actualización del jugador
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJugador(int id)
        {
            // Simulación de eliminación del jugador
            return NoContent();
        }
    }
}
