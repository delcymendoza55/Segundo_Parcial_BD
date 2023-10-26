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
    public class PersonasDatos
    {
        private ConexionDB conexion;
        public PersonasDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }
        public void insertarPersona(PersonasModel Personas)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand("INSERT INTO Personas(Id_Ciudad,Nombre,Apellido,Tipo_Docu,Nro_Docu,Direccion,Celular,Email,Estado)" +
                "VALUES(@Id_Ciudad,@Nombre,@Apellido,@Tipo_Docu,@Nro_Docu,@Direccion,@Celular,@Email,@Estado)", conn);
            comando.Parameters.AddWithValue("Id_Ciudad", Personas.Id_Ciudad);
            comando.Parameters.AddWithValue("Nombre", Personas.Nombre);
            comando.Parameters.AddWithValue("Apellido", Personas.Apellido);
            comando.Parameters.AddWithValue("Tipo_Docu", Personas.Tipo_Docu);
            comando.Parameters.AddWithValue("Nro_Docu", Personas.Nro_Docu);
            comando.Parameters.AddWithValue("Direccion", Personas.Direccion);
            comando.Parameters.AddWithValue("Celular", Personas.Celular);
            comando.Parameters.AddWithValue("Email", Personas.Email);
            comando.Parameters.AddWithValue("Estado", Personas.Estado);

            comando.ExecuteNonQuery();
        }

        public PersonasModel obtenerPersonaPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand($"Select * from Personas where id_persona = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new PersonasModel
                {
                    Id_Persona = reader.GetInt32("id_persona"),
                    Id_Ciudad = reader.GetInt32("id_ciudad"),
                    Nombre = reader.GetString("Nombre"),
                    Apellido = reader.GetString("Apellido"),
                    Tipo_Docu = reader.GetString("Tipo_Docu"),
                    Nro_Docu = reader.GetString("Nro_Docu"),
                    Direccion = reader.GetString("Direccion"),
                    Celular = reader.GetString("Celular"),
                    Email = reader.GetString("Email"),
                    Estado = reader.GetString("Estado"),

                };
            }
            return null;
        }      
        public void modificarPersona(PersonasModel personas)
        {
           var conn = conexion.GetConexion();
           var comando = new Npgsql.NpgsqlCommand($"UPDATE personas SET " +
               $"Id_Ciudad = '{personas.Id_Ciudad}', " +
                         $"Nombre = '{personas.Nombre}', " +
                         $"Apellido = '{personas.Apellido}', " +
                         $"Tipo_Docu = '{personas.Tipo_Docu}', " +
                         $"Nro_Docu = '{personas.Nro_Docu}', " +
                         $"Direccion = '{personas.Direccion}', " +
                         $"Celular = '{personas.Celular}', " +
                         $"Email = '{personas.Email}', " +
                         $"Estado = '{personas.Estado}' " +
                     $" WHERE id_persona = {personas.Id_Persona}", conn);

           comando.ExecuteNonQuery();
        }
        public void eliminarPersona(PersonasModel personas)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM personas WHERE" +
                $"id_persona = '{personas.Id_Persona}'", conn);

            comando.ExecuteNonQuery();
        }
    }

}
