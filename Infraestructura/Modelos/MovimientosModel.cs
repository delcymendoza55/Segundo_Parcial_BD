using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class MovimientosModel
    {
        public int Id_Movimiento { get; set; }
        public int Id_Cuenta { get; set; }
        public DateTime Fecha_Movimiento { get; set; }
        public string Tipo_Movimiento { get; set; }
        public Decimal Saldo_Anterior { get; set; }
        public Decimal Saldo_Actual { get; set; }
        public Decimal Monto_Movimiento { get; set; }
        public Decimal Cuenta_Origen { get; set; }
        public Decimal Cuenta_Destino { get; set; }
        public Decimal Canal { get; set; }
        
    }
}