using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class PersonasModel
    {
        public int Id_Persona { get; set; }
        public int Id_Ciudad { get; set; }
        public string Nombre{ get; set; }
        public string Apellido { get; set; }
        public string Tipo_Docu { get; set; }
        public string Nro_Docu { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }


    }
}