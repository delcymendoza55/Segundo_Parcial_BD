using Infraestructura.Datos;
using Infraestructura.Modelos;
using System.Runtime.CompilerServices;

namespace Servicios.ContactService
{
    public class CiudadesService
    {
        CiudadesDatos ciudadesDatos;
        public CiudadesService(string cadenaConexion) 
        { 
            ciudadesDatos= new CiudadesDatos(cadenaConexion);
        }
        public void insertarCiudad(CiudadesModel Ciudades)
        {
            validarDatos(Ciudades);
            ciudadesDatos.insertarCiudad(Ciudades);
        }

        public CiudadesModel obtenerCiudad(int id)
        {
            return ciudadesDatos.obtenerCiudadPorId(id);
        }
        public void modificarCiudad(CiudadesModel Ciudades)
        {
            validarDatos(Ciudades);
            ciudadesDatos.modificarCiudad(Ciudades);
        }
        public void eliminarCiudad(CiudadesModel Ciudades)
        {
            validarDatos(Ciudades);
            ciudadesDatos.eliminarCiudad(Ciudades);
        }
        private void validarDatos(CiudadesModel Ciudades)
            {
            if (Ciudades.Ciudad.Trim().Length < 2)
            {
                throw new Exception("La descripción no debe estar nulo");
            }
        }

        public void eliminarCiudad(int id_Ciudad)
        {
            throw new NotImplementedException();
        }
    }
}
