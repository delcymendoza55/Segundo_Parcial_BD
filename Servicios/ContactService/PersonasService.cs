using Infraestructura.Conexiones;
using Infraestructura.Datos;
using Infraestructura.Modelos;

namespace Servicios.ContactService
{
    public class PersonasService
    {
        PersonasDatos personasDatos;
        public PersonasService(string cadenaConexion)
        {
            personasDatos = new PersonasDatos(cadenaConexion);
        }
        public void insertarPersona(PersonasModel Personas)
        {
            personasDatos.insertarPersona(Personas);
        }
        public PersonasModel obtenerPersona(int id)
        {
            return personasDatos.obtenerPersonaPorId(id);
        }
        public void modificarPersona(PersonasModel Personas)
        {
            validarDatos(Personas);
            personasDatos.modificarPersona(Personas);
        }
        public void eliminarPersonas(PersonasModel Personas)
        {
            validarDatos(Personas);
            personasDatos.eliminarPersona(Personas);
        }
        private void validarDatos(PersonasModel Personas)
        {
            if (Personas.Nombre.Trim().Length < 2)
            {
                throw new Exception("La descripción no debe estar nulo");
            }
        }

        public void eliminarPersona(int id_Persona)
        {
            throw new NotImplementedException();
        }
    }
}
