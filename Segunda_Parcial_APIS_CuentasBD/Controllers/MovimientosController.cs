using Microsoft.AspNetCore.Mvc;
using Servicios.ContactService;
using Infraestructura.Modelos;


namespace Segunda_Parcial_APIS_CuentasBD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientosController : ControllerBase
    {
        private const string connectionString = "Host=localhost;User Id=postgres;Password=1234;Database=Cuentas_Primer_Parcial;";
        private MovimientosService servicios;

        public MovimientosController()
        {
            servicios = new MovimientosService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerMovimientoAccion([FromRoute] int id)
        {
            var movimientos = servicios.obtenerMovimiento(id);
            return Ok(movimientos);
        }

        [HttpGet("por-parametro")]
        public IActionResult ObtenerMovimientosAccion2([FromQuery] int id)
        {
            var movimientos = servicios.obtenerMovimiento(id);
            return Ok(movimientos);
        }

        [HttpPost]
        public IActionResult InsertarMovimientoAccion([FromBody] Infraestructura.Modelos.MovimientosModel movimientos)
        {
            servicios.insertarMovimiento(movimientos);
            return Created("Se creo con exito!!", movimientos);
        }

        [HttpPut]
        public IActionResult ModificarCiudadAccion([FromBody] Infraestructura.Modelos.MovimientosModel movimientos)
        {
            servicios.modificarMovimiento(movimientos);
            return Ok("Se actualizo con exito!!");
        }
        [HttpDelete("{id}")]
        public IActionResult EliminarMovimientoAccion([FromRoute] int id_Movimiento)
        {
            try
            {
                servicios.eliminarMovimiento(id_Movimiento);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la ciudad: {ex.Message}");
            }
        }
    }
}
