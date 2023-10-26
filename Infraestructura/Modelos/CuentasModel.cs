using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class CuentasModel
    {
        public int Id_Cuenta { get; set; }
        public int Id_Cliente { get; set; }
        public string Nro_Cuenta { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public string Tipo_Cuenta { get; set; }
        public string Estado { get; set; }
        public decimal Saldo { get; set; }
        public string nroCuenta { get; set; }
        public string nroContrato { get; set; }
        public decimal Costo_Mantenimiento { get; set; }
        public string Promedio_Acreditacion { get; set; }
        public string Moneda { get; set; }
      
    }
}