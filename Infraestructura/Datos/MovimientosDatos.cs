using Infraestructura.Conexiones;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Modelos;
using System.Data;

namespace Infraestructura.Datos
{
    public class MovimientosDatos
    {
        private ConexionDB conexion;
        public MovimientosDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }
        public void insertarMovimiento(MovimientosModel Movimientos)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO Movimientos(Id_Cuenta,Fecha_Movimiento,Tipo_Movimiento,Saldo_Anterior,Saldo_Actual,Monto_Movimiento,Cuenta_Origen,Cuenta_Destino,Canal)" +
                "VALUES(@Id_Cuenta,@Fecha_Movimiento,@Tipo_Movimiento,@Saldo_Anterior,@Saldo_Actual,@Monto_Movimiento,@Cuenta_Origen,@Cuenta_Destino,@Canal)", conn);
            comando.Parameters.AddWithValue("Id_Cuenta", Movimientos.Id_Cuenta);
            comando.Parameters.AddWithValue("Fecha_Movimiento", Movimientos.Fecha_Movimiento);
            comando.Parameters.AddWithValue("Tipo_Movimiento", Movimientos.Tipo_Movimiento);
            comando.Parameters.AddWithValue("Saldo_Anterior", Movimientos.Saldo_Anterior);
            comando.Parameters.AddWithValue("Saldo_Actual", Movimientos.Saldo_Actual);
            comando.Parameters.AddWithValue("Monto_Movimiento", Movimientos.Monto_Movimiento);
            comando.Parameters.AddWithValue("Cuenta_Origen", Movimientos.Cuenta_Origen);
            comando.Parameters.AddWithValue("Cuenta_Destino", Movimientos.Cuenta_Destino);
            comando.Parameters.AddWithValue("Canal", Movimientos.Canal);
            
            comando.ExecuteNonQuery();
        }

        public MovimientosModel obtenerMovimientoPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand($"Select * from Movimientos where id_Movimiento = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new MovimientosModel
                {
                    Id_Cuenta = reader.GetInt32("id_cuenta"),
                    Fecha_Movimiento = reader.GetDateTime("Fecha_Movimiento"),
                    Tipo_Movimiento = reader.GetString("Tipo_Movimiento"),
                    Saldo_Anterior = reader.GetDecimal("Saldo_Anterior"),
                    Saldo_Actual = reader.GetDecimal("Saldo_Actual"),
                    Monto_Movimiento = reader.GetDecimal("Monto_Movimiento"),
                    Cuenta_Origen = reader.GetDecimal("Cuenta_Origen"),
                    Cuenta_Destino = reader.GetDecimal("Cuenta_Destino"),
                    Canal = reader.GetDecimal("Canal")

                };
            }
            return null;
        }
        //public void modificarMovimiento(MovimientosModel movimientos)
        //{
        //    var conn = conexion.GetConexion();
        //    var comando = new NpgsqlCommand($"UPDATE movimientos SET Id_Cuenta = '{movimientos.Id_Cuenta}', " +
        //                                                  $"Fecha_Movimiento = '{movimientos.Fecha_Movimiento}', " +
        //                                                  $"Tipo_Movimiento = '{movimientos.Tipo_Movimiento}', " +
        //                                                  $"Saldo_Anterior= '{movimientos.Saldo_Anterior}', " +
        //                                                  $"Saldo_Actual = '{movimientos.Saldo_Actual}', " +
        //                                                  $"Monto_Movimiento = '{movimientos.Monto_Movimiento}', " +
        //                                                  $"Cuenta_Origen = '{movimientos.Cuenta_Origen}', " +
        //                                                  $"Cuenta_Destino = '{movimientos.Cuenta_Destino}', " +
        //                                                  $"Canal = '{movimientos.Canal}' " +
        //                                        $" WHERE id_movimiento = {movimientos.Id_Movimiento}", conn);

        //    comando.ExecuteNonQuery();
        //}
        public void modificarMovimiento(MovimientosModel movimientos)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand("UPDATE movimientos SET Id_Cuenta = @Id_Cuenta, " +
                                            "Fecha_Movimiento = @Fecha_Movimiento, " +
                                            "Tipo_Movimiento = @Tipo_Movimiento, " +
                                            "Saldo_Anterior = @Saldo_Anterior, " +
                                            "Saldo_Actual = @Saldo_Actual, " +
                                            "Monto_Movimiento = @Monto_Movimiento, " +
                                            "Cuenta_Origen = @Cuenta_Origen, " +
                                            "Cuenta_Destino = @Cuenta_Destino, " +
                                            "Canal = @Canal " +
                                            "WHERE id_movimiento = @Id_Movimiento", conn);

            comando.Parameters.AddWithValue("@Id_Cuenta", movimientos.Id_Cuenta);
            comando.Parameters.AddWithValue("@Fecha_Movimiento", movimientos.Fecha_Movimiento);
            comando.Parameters.AddWithValue("@Tipo_Movimiento", movimientos.Tipo_Movimiento);
            comando.Parameters.AddWithValue("@Saldo_Anterior", movimientos.Saldo_Anterior);
            comando.Parameters.AddWithValue("@Saldo_Actual", movimientos.Saldo_Actual);
            comando.Parameters.AddWithValue("@Monto_Movimiento", movimientos.Monto_Movimiento);
            comando.Parameters.AddWithValue("@Cuenta_Origen", movimientos.Cuenta_Origen);
            comando.Parameters.AddWithValue("@Cuenta_Destino", movimientos.Cuenta_Destino);
            comando.Parameters.AddWithValue("@Canal", movimientos.Canal);
            comando.Parameters.AddWithValue("@Id_Movimiento", movimientos.Id_Movimiento);

            comando.ExecuteNonQuery();
        }





        public void eliminarMovimiento(MovimientosModel Movimientos)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand($"DELETE FROM Movimientos WHERE" +
                $"id_Movimiento = '{Movimientos.Id_Movimiento}'", conn);

            comando.ExecuteNonQuery();
        }
    }
}
