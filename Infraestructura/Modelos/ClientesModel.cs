using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class ClientesModel
    {
        public int Id_Cliente { get; set; }
        public int Id_Persona { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public string Calificacion { get; set; }
        public string Estado { get; set; }
        

    }
}