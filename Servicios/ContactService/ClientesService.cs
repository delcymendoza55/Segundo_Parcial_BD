using Infraestructura.Conexiones;
using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactService
{
    public class ClientesService
    {
        ClientesDatos clientesDatos;
        public ClientesService(string cadenaConexion)
        {
            clientesDatos = new ClientesDatos(cadenaConexion);
        }
        public void insertarCliente(ClientesModel Clientes)
        {
            clientesDatos.insertarCliente(Clientes);
        }
        public ClientesModel obtenerCliente(int id)
        {
            return clientesDatos.obtenerClientePorId(id);
        }
        public void modificarCliente(ClientesModel Clientes)
        {
            validarDatos(Clientes);
            clientesDatos.modificarCliente(Clientes);
        }
        public void eliminarCliente(ClientesModel Clientes)
        {
            validarDatos(Clientes);
            clientesDatos.eliminarCliente(Clientes);
        }
        private void validarDatos(ClientesModel Clientes)
        {
            if (Clientes.Calificacion.Trim().Length < 2)
            {
                throw new Exception("La descripción no debe estar nulo");
            }
        }

        public void eliminarCliente(int id_Cliente)
        {
            throw new NotImplementedException();
        }
    }
}
