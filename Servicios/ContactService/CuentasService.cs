using Infraestructura.Conexiones;
using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactService
{
    public class CuentasService
    {
        CuentasDatos cuentasDatos;
        public CuentasService(string cadenaConexion)
        {
            cuentasDatos = new CuentasDatos(cadenaConexion);
        }
        public void insertarCuenta(CuentasModel Cuentas)
        {
            cuentasDatos.insertarCuenta(Cuentas);
        }
        public CuentasModel obtenerCuenta(int id)
        {
            return cuentasDatos.obtenerCuentaPorId(id);
        }
        public void modificarCuenta(CuentasModel Cuentas)
        {
            validarDatos(Cuentas);
            cuentasDatos.modificarCuenta(Cuentas);
        }
        public void eliminarCuenta(CuentasModel Cuentas)
        {
            validarDatos(Cuentas);
            cuentasDatos.eliminarCuenta(Cuentas);
        }
        private void validarDatos(CuentasModel Cuentas)
        {
            if (Cuentas.Nro_Cuenta.Trim().Length < 2)
            {
                throw new Exception("La descripción no debe estar nulo");
            }
        }

        public void eliminarCuenta(int id_Cuenta)
        {
            throw new NotImplementedException();
        }
    }
}