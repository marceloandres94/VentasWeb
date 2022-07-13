using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class CD_IndicadorVenta
    {
        public static CD_IndicadorVenta _instancia = null;

        private CD_IndicadorVenta()
        {

        }

        public static CD_IndicadorVenta Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_IndicadorVenta();
                }
                return _instancia;
            }
        }
    }
}
