using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class IndicadorFechaVencimiento
    {
        public int IdTienda { get; set; }
        public int SinProblemas { get; set; }
        public int PorVencer { get; set; }
        public int Vencidos { get; set; }
    }
}
