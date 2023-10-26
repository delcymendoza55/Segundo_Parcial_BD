using Microsoft.AspNetCore.Mvc;
using Servicios.ContactService;
using Infraestructura.Modelos;
using Primer_Parcial_Cuentas.Cuentas_Parcial1;


namespace Segunda_Parcial_APIS_CuentasBD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentasController : ControllerBase
    {
        private const string connectionString = "Host=localhost;User Id=postgres;Password=1234;Database=Cuentas_Primer_Parcial;";
        private CuentasService servicios;

        public CuentasController()
        {
            servicios = new CuentasService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerCuentasAccion([FromRoute] int id)
        {
            var cuentas = servicios.obtenerCuenta(id);
            return Ok(cuentas);
        }

        [HttpGet("por-parametro")]
        public IActionResult ObtenerCiudadAccion2([FromQuery] int id)
        {
            var cuentas = servicios.obtenerCuenta(id);
            return Ok(cuentas);
        }

        [HttpPost]
        public IActionResult InsertarCuentaAccion([FromBody] Infraestructura.Modelos.CuentasModel cuentas)
        {
            servicios.insertarCuenta(cuentas);
            return Created("Se creo con exito!!", cuentas);
        }

        [HttpPut]
        public IActionResult ModificarCuentaAccion([FromBody] Infraestructura.Modelos.CuentasModel cuentas)
        {
            servicios.modificarCuenta(cuentas);
            return Ok("Se actualizo con exito!!");
        }
        [HttpDelete("{id}")]
        public IActionResult EliminarCuentaAccion([FromRoute] int id_Cuenta)
        {
            try
            {
                servicios.eliminarCuenta(id_Cuenta);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la ciudad: {ex.Message}");
            }
        }
    }
}