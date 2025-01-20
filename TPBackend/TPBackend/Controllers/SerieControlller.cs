using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

namespace TPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerieController : ControllerBase
    {
        // Clase Serie que coincide con la estructura de tu tabla
        public class Serie
        {
            public int IdSerie { get; set; }
            public string Nombre { get; set; }
            public List<int> ListaCartas { get; set; } // IDs de cartas asociadas
            public DateTime FechaSalida { get; set; }
        }

        [HttpPost]
        public IActionResult CreateSerie([FromBody] Serie serie)
        {
            // Simulación de creación de la serie
            return CreatedAtAction(nameof(GetSerieById), new { id = serie.IdSerie }, serie);
        }

        [HttpGet]
        public IActionResult GetSeries()
        {
            // Simulación de obtener series
            var series = new List<Serie>
            {
                new Serie
                {
                    IdSerie = 1,
                    Nombre = "Serie A",
                    ListaCartas = new List<int> { 1, 2, 3 },
                    FechaSalida = new DateTime(2023, 6, 15)
                },
                new Serie
                {
                    IdSerie = 2,
                    Nombre = "Serie B",
                    ListaCartas = new List<int> { 4, 5 },
                    FechaSalida = new DateTime(2024, 1, 10)
                }
            };

            return Ok(series);
        }

        [HttpGet("{id}")]
        public IActionResult GetSerieById(int id)
        {
            // Simulación de obtener una serie por ID
            var serie = new Serie
            {
                IdSerie = id,
                Nombre = "Serie A",
                ListaCartas = new List<int> { 1, 2, 3 },
                FechaSalida = new DateTime(2023, 6, 15)
            };

            if (serie == null)
            {
                return NotFound();
            }

            return Ok(serie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSerie(int id, [FromBody] Serie serie)
        {
            if (id != serie.IdSerie)
            {
                return BadRequest("El ID de la serie no coincide.");
            }

            // Simulación de actualización de la serie
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSerie(int id)
        {
            // Simulación de eliminación de la serie
            return NoContent();
        }
    }
}
