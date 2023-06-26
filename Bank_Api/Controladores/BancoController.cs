using Bank_Api.DTO;
using Bank_Api.Servicios;
using BaseDatos.DBContext;
using BaseDatos.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace Bank_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IServicioBanco _servicioBanco;
        public BancoController(IServicioBanco servicioBanco) 
        {
            _servicioBanco = servicioBanco;
        }
        [HttpPost("poblar-basedatos")]
        public async Task<IActionResult> PoblarBaseDatos()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://random-data-api.com/api/v2/banks?size=100");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var filas = _servicioBanco.PoblarBaseDatos(json);
                return Ok("Base de datos poblada exitosamente.");
            }
            return StatusCode(500, "Error al obtener los datos de la API.");
        }

        [HttpPost("crearBanco")]
        public async Task<IActionResult> Crearbanco([FromBody] BancoCreadorDto nuevoBanco)
        {
            if (nuevoBanco == null) 
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var creado = _servicioBanco.InsertarBanco(nuevoBanco);
            return Ok(creado);
        }
    }
}
