using Microsoft.AspNetCore.Mvc;
using Servicios.ContactService;
using Infraestructura.Modelos;


namespace Segunda_Parcial_APIS_CuentasBD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private const string connectionString = "Host=localhost;User Id=postgres;Password=1234;Database=Cuentas_Primer_Parcial;";
        private ClientesService servicios;

        public ClientesController()
        {
            servicios = new ClientesService(connectionString);
        }

        [HttpGet("por-ruta/{id}")]
        public IActionResult ObtenerClienteAccion([FromRoute] int id)
        {
            var clientes = servicios.obtenerCliente(id);
            return Ok(clientes);
        }

        [HttpGet("por-parametro")]
        public IActionResult ObtenerCiudadAccion2([FromQuery] int id)
        {
            var clientes = servicios.obtenerCliente(id);
            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult InsertarClienteAccion([FromBody] Infraestructura.Modelos.ClientesModel clientes)
        {
            servicios.insertarCliente(clientes);
            return Created("Se creo con exito!!", clientes);
        }

        [HttpPut]
        public IActionResult ModificarClienteAccion([FromBody] Infraestructura.Modelos.ClientesModel clientes)
        {
            servicios.modificarCliente(clientes);
            return Ok("Se actualizo con exito!!");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarClienteAccion([FromRoute] int id_Cliente)
        {
            try
            {
                servicios.eliminarCliente(id_Cliente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la ciudad: {ex.Message}");
            }
        }
    }
}