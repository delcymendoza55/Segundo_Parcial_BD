using Infraestructura.Conexiones;
using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactService
{
    public class MovimientosService
    {
        MovimientosDatos movimientosDatos;
        public MovimientosService(string cadenaConexion)
        {
            movimientosDatos = new MovimientosDatos(cadenaConexion);
        }
        public void insertarMovimiento(MovimientosModel Movimientos)
        {
            movimientosDatos.insertarMovimiento(Movimientos);
        }
        public MovimientosModel obtenerMovimiento(int id)
        {
            return movimientosDatos.obtenerMovimientoPorId(id);
        }
        public void modificarMovimiento(MovimientosModel Movimientos)
        {
            validarDatos(Movimientos);
            movimientosDatos.modificarMovimiento(Movimientos);
        }
        public void eliminarMovimiento(MovimientosModel Movimientos)
        {
            validarDatos(Movimientos);
            movimientosDatos.eliminarMovimiento(Movimientos);
        }
        private void validarDatos(MovimientosModel Movimientos)
        {
            if (Movimientos.Tipo_Movimiento.Trim().Length < 2)
            {
                throw new Exception("La descripción no debe estar nulo");
            }
        }

        public void eliminarMovimiento(int id_Movimiento)
        {
            throw new NotImplementedException();
        }
    }
}