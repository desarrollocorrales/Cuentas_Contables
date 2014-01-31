using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportarCuentasContables.clases
{
    public class Cliente
    {
        public int ID_Microsip { set; get; }
        public string Nombre { set; get; }
        public string Cuenta_CO { set; get; }
        public int iConsecutivo { set; get; }
        public bool Status { set; get; }
    }
}
