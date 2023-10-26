using Microsoft.AspNetCore.Mvc;
using Servicios.ContactService;
using Infraestructura.Modelos;


namespace Segunda_Parcial_APIS_CuentasBD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CiudadesController : ControllerBase
    {
        private const string connectionString = "Host=localhost;User Id=postgres;Password=1234;Database=Cuentas_Primer_Parcial;";
        private CiudadesService servicios;

        public CiudadesController()
        {
            servicios = new CiudadesService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerCiudadAccion([FromRoute] int id_ciudad)
        {
            var ciudades = servicios.obtenerCiudad(id_ciudad);
            return Ok(ciudades);
        }

        [HttpGet("por-parametro")]
        public IActionResult ObtenerCiudadAccion2([FromQuery] int id)
        {
            var ciudades = servicios.obtenerCiudad(id);
            return Ok(ciudades);
        }

        [HttpPost]
        public IActionResult InsertarCiudadAccion([FromBody] Infraestructura.Modelos.CiudadesModel ciudades)
        {
            servicios.insertarCiudad(ciudades);
            return Created("Se creo con exito!!", ciudades);
        }

        [HttpPut]
        public IActionResult ModificarCiudadAccion([FromBody] Infraestructura.Modelos.CiudadesModel ciudades)
        {
            servicios.modificarCiudad(ciudades);
            return Ok("Se actualizo con exito!!");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCiudadAccion([FromRoute] int id_Ciudad)
        {
            try
            {
                servicios.eliminarCiudad(id_Ciudad);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la ciudad: {ex.Message}");
            }
        }
    }
}