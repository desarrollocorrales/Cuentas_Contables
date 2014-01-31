using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccSettings;

namespace ImportarCuentasContables.clases
{
    public class ConfiguracionMicrosip
    {
        public string empresa { get; set; }
        public string path { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public string port { get; set; }
        public string MysqlDatabase { set; get; }
        public string errorMessage { set; get; }
        
    }
}
