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
    public class CiudadesDatos
    {
        private ConexionDB conexion;
        public CiudadesDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }
        public void insertarCiudad(CiudadesModel Ciudades)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO Ciudades(Ciudad,Departamento,Cod_Postal)"+
                "VALUES(@Ciudad,@Departamento,@Cod_Postal)",conn);
            comando.Parameters.AddWithValue("Ciudad",Ciudades.Ciudad);
            comando.Parameters.AddWithValue("Departamento", Ciudades.Departamento);
            comando.Parameters.AddWithValue("Cod_Postal", Ciudades.Cod_Postal);
            
            comando.ExecuteNonQuery();
        }
        public CiudadesModel obtenerCiudadPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new NpgsqlCommand($"Select * from Ciudades where id_ciudad = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new CiudadesModel
                {
                    Id_Ciudad = reader.GetInt32("id_ciudad"),
                    Ciudad = reader.GetString("Ciudad"),
                    Departamento = reader.GetString("Departamento"),
                    Cod_Postal = reader.GetInt32("Cod_Postal"),
                };
            }
            return null;
        }
        public void modificarCiudad(CiudadesModel ciudades)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE ciudades SET Ciudad = '{ciudades.Ciudad}', " +
                                                          $"Departamento = '{ciudades.Departamento}', " +
                                                          $"Cod_Postal = '{ciudades.Cod_Postal}' " +
                                                $" WHERE id_ciudad = {ciudades.Id_Ciudad}", conn);

            comando.ExecuteNonQuery();
        }

        public void eliminarCiudad(CiudadesModel ciudades)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM ciudades WHERE" +
                $"id_ciudad = '{ciudades.Id_Ciudad}'", conn);

            comando.ExecuteNonQuery();
        }
    }
}

    


   
