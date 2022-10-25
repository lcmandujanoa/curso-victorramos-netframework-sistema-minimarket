using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Minimarket.Entidades
{
    public class E_Salida_Productos
    {
        public int Codigo_sp { get; set; }
        public int Codigo_tde { get; set; }
        public string Nrodocumento_sp { get; set; }
        public int Codigo_cl { get; set; }
        public string Nrodocumento_cl { get; set; }
        public string Razon_social_cl { get; set; }
        public DateTime Fecha_sp { get; set; }
        public string Observacion_sp { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total_importe { get; set; }
    }
}
