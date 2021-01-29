using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteresCompuestoCalculo
{
    public class ObtenerValorDolar
    {
        public string ApiVersion { get; set; }
        public Data dolar { get; set; }
    }

    public class Data
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string unidad_medida { get; set; }
        public string fecha { get; set; }
        public double valor { get; set; }
    }
}
