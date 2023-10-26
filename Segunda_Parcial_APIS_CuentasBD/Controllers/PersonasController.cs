using Microsoft.AspNetCore.Mvc;
using Servicios.ContactService;
using Infraestructura.Modelos;


namespace Segunda_Parcial_APIS_CuentasBD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase
    {
        private const string connectionString = "Host=localhost;User Id=postgres;Password=1234;Database=Cuentas_Primer_Parcial;";
        private PersonasService servicios;

        public PersonasController()
        {
            servicios = new PersonasService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerPersonaAccion([FromRoute] int id)
        {
            var personas = servicios.obtenerPersona(id);
            return Ok(personas);
        }

        [HttpGet("por-parametro")]
        public IActionResult ObtenerPersonaAccion2([FromQuery] int id)
        {
            var personas = servicios.obtenerPersona(id);
            return Ok(personas);
        }

        [HttpPost]
        public IActionResult InsertarPersonaAccion([FromBody] Infraestructura.Modelos.PersonasModel personas)
        {
            servicios.insertarPersona(personas);
            return Created("Se creo con exito!!", personas);
        }

        [HttpPut]
        public IActionResult ModificarPersonaAccion([FromBody] Infraestructura.Modelos.PersonasModel personas)
        {
            servicios.modificarPersona(personas);
            return Ok("Se actualizo con exito!!");
        }
        [HttpDelete("{id}")]
        public IActionResult EliminarPersonaAccion([FromRoute] int id_Persona)
        {
            try
            {
                servicios.eliminarPersona(id_Persona);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la ciudad: {ex.Message}");
            }
        }
    }
}