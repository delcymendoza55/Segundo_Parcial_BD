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
    public class CuentasDatos
    {
        private ConexionDB conexion;
        public CuentasDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }
        public void insertarCuenta(CuentasModel Cuentas)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand("INSERT INTO Cuentas(Id_Cliente,Nro_Cuenta, Fecha_Alta, Tipo_Cuenta,Estado,Saldo,nroCuenta,nroContrato,Costo_Mantenimiento,Promedio_Acreditacion,Moneda)" +
                "VALUES(@Id_Cliente,@Nro_Cuenta, @Fecha_Alta, @Tipo_Cuenta,@Estado,@Saldo,@nroCuenta,@nroContrato,@Costo_Mantenimiento,@Promedio_Acreditacion,@Moneda)",conn);
            comando.Parameters.AddWithValue("Id_Cliente", Cuentas.Id_Cliente);
            comando.Parameters.AddWithValue("Nro_Cuenta", Cuentas.Nro_Cuenta);
            comando.Parameters.AddWithValue("Fecha_Alta", Cuentas.Fecha_Alta);
            comando.Parameters.AddWithValue("Tipo_Cuenta", Cuentas.Tipo_Cuenta);
            comando.Parameters.AddWithValue("Estado", Cuentas.Estado);
            comando.Parameters.AddWithValue("Saldo", Cuentas.Saldo);
            comando.Parameters.AddWithValue("nroCuenta", Cuentas.nroCuenta);
            comando.Parameters.AddWithValue("nroContrato", Cuentas.nroContrato);
            comando.Parameters.AddWithValue("Costo_Mantenimiento", Cuentas.Costo_Mantenimiento);
            comando.Parameters.AddWithValue("Promedio_Acreditacion", Cuentas.Promedio_Acreditacion);
            comando.Parameters.AddWithValue("Moneda", Cuentas.Moneda);

            comando.ExecuteNonQuery();
        }

        public CuentasModel obtenerCuentaPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand($"Select * from Cuentas where id_Cuenta = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new CuentasModel
                {
                    Id_Cliente = reader.GetInt32("id_cliente"),
                    Nro_Cuenta = reader.GetString("Nro_Cuenta"),
                    Fecha_Alta = reader.GetDateTime("Fecha_Alta"),
                    Tipo_Cuenta = reader.GetString("Tipo_Cuenta"),
                    Estado = reader.GetString("Estado"),
                    Saldo = reader.GetDecimal("Saldo"),
                    nroCuenta = reader.GetString("nroCuenta"),
                    nroContrato = reader.GetString("nroContrato"),
                    Costo_Mantenimiento = reader.GetDecimal("Costo_Mantenimiento"),
                    Promedio_Acreditacion = reader.GetString("Promedio_Acreditacion"),
                    Moneda = reader.GetString("Moneda"),

                };
            }
            return null;
        }
        //public void modificarCuenta(CuentasModel cuentas)
        //{
        //    var conn = conexion.GetConexion();
        //    var comando = new NpgsqlCommand($"UPDATE cuentas SET id_Cliente = '{cuentas.Id_Cliente}'," +
        //                                      $"Nro_Cuenta = '{cuentas.Nro_Cuenta}', " +
        //                                      $"Fecha_Alta = '{cuentas.Fecha_Alta}', " +
        //                                      $"Tipo_Cuenta= '{cuentas.Tipo_Cuenta}', " +
        //                                      $"Estado = '{cuentas.Estado}', " +
        //                                      $"Saldo = '{cuentas.Saldo}', " +
        //                                      $"nroCuenta = '{cuentas.nroCuenta}', " +
        //                                      $"nroContrato = '{cuentas.nroContrato}', " +
        //                                      $"Costo_Mantenimiento = '{cuentas.Costo_Mantenimiento}', " +
        //                                      $"Promedio_Acreditacion = '{cuentas.Promedio_Acreditacion}', " +
        //                                      $"Moneda = '{cuentas.Moneda}' " +
        //                               $"WHERE id_cuenta = {cuentas.Id_Cuenta}", conn);
        //    comando.ExecuteNonQuery();
        //}

        public void modificarCuenta(CuentasModel cuentas)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand("UPDATE cuentas SET id_Cliente = @Id_Cliente, " +
                                              "Nro_Cuenta = @Nro_Cuenta, " +
                                              "Fecha_Alta = @Fecha_Alta, " +
                                              "Tipo_Cuenta = @Tipo_Cuenta, " +
                                              "Estado = @Estado, " +
                                              "Saldo = @Saldo, " +
                                              "nroCuenta = @nroCuenta, " +
                                              "nroContrato = @nroContrato, " +
                                              "Costo_Mantenimiento = @Costo_Mantenimiento, " +
                                              "Promedio_Acreditacion = @Promedio_Acreditacion, " +
                                              "Moneda = @Moneda " +
                                       "WHERE id_cuenta = @Id_Cuenta", conn);

            comando.Parameters.AddWithValue("@Id_Cliente", cuentas.Id_Cliente);
            comando.Parameters.AddWithValue("@Nro_Cuenta", cuentas.Nro_Cuenta);
            comando.Parameters.AddWithValue("@Fecha_Alta", cuentas.Fecha_Alta);
            comando.Parameters.AddWithValue("@Tipo_Cuenta", cuentas.Tipo_Cuenta);
            comando.Parameters.AddWithValue("@Estado", cuentas.Estado);
            comando.Parameters.AddWithValue("@Saldo", cuentas.Saldo);
            comando.Parameters.AddWithValue("@nroCuenta", cuentas.nroCuenta);
            comando.Parameters.AddWithValue("@nroContrato", cuentas.nroContrato);
            comando.Parameters.AddWithValue("@Costo_Mantenimiento", cuentas.Costo_Mantenimiento);
            comando.Parameters.AddWithValue("@Promedio_Acreditacion", cuentas.Promedio_Acreditacion);
            comando.Parameters.AddWithValue("@Moneda", cuentas.Moneda);
            comando.Parameters.AddWithValue("@Id_Cuenta", cuentas.Id_Cuenta);

            comando.ExecuteNonQuery();
        }

        public void eliminarCuenta(CuentasModel Cuentas)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand($"DELETE FROM Cuentas WHERE" +
                $"id_Cuenta = '{Cuentas.Id_Cuenta}'", conn);

            comando.ExecuteNonQuery();
        }
    }
}
