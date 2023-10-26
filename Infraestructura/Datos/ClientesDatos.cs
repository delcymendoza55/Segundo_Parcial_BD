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
    public class ClientesDatos
    {
        private ConexionDB conexion;
        private int Fecha_Ingreso;

        public ClientesDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }
        public void insertarCliente(ClientesModel Clientes)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO Clientes(Id_persona,Fecha_Ingreso,Calificacion,Estado)" +
                "VALUES(@Id_persona,@Fecha_Ingreso,@Calificacion,@Estado)", conn);
            comando.Parameters.AddWithValue("Id_persona", Clientes.Id_Persona);
            comando.Parameters.AddWithValue("Fecha_Ingreso", Clientes.Fecha_Ingreso);
            comando.Parameters.AddWithValue("Calificacion", Clientes.Calificacion);
            comando.Parameters.AddWithValue("Estado", Clientes.Estado);

            comando.ExecuteNonQuery();
        }
        public ClientesModel obtenerClientePorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand($"Select * from Clientes where id_cliente = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new ClientesModel
                {
                    Id_Persona= reader.GetInt32("id_persona"),
                    Fecha_Ingreso= reader.GetDateTime("Fecha_Ingreso"),
                    Calificacion= reader.GetString("Calificacion"),
                    Estado=reader.GetString("Estado"),

                };
            }
            return null;
        }
        public void modificarCliente(ClientesModel clientes)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand($"UPDATE clientes SET Id_Persona = '{clientes.Id_Persona}', " +
                                                          $"Fecha_Ingreso = '{clientes.Fecha_Ingreso}', " +
                                                          $"Calificacion = '{clientes.Calificacion}', " +
                                                          $"Estado = '{clientes.Estado}' " +
                                                $" WHERE id_cliente = {clientes.Id_Cliente}", conn);

            comando.ExecuteNonQuery();
        }

        public void eliminarCliente(ClientesModel Clientes)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand($"DELETE FROM clientes WHERE" +
                $"id_ciudad = '{Clientes.Id_Cliente}'", conn);

            comando.ExecuteNonQuery();
        }
    }
}

