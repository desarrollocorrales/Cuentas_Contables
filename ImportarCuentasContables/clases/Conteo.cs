using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportarCuentasContables.clases
{
    public class Conteo
    {
        public int IdConteo { set; get; }
        public string CuentaPadre { set; get; }
        public int IdMicroCuentaPadre { set; get; }
        public int iConteo { set; get; }
        public string Sucursal { set; get; }
        public bool Status { set; get; }
    }
}
