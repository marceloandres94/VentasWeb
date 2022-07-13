using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class IndicadorStock
    {
        public int IdTienda { get; set; }
        public int StockDisponible { get; set; }
        public int StockAgotado { get; set; }
        public int StockCritico { get; set; }
    }
}
