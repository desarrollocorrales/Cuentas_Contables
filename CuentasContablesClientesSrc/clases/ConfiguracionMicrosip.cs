using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccSettings;

namespace CuentasContablesClientesSrc.clases
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

        public bool LoadConfiguration()
        {
            bool bSuccess = false;

            //Obtener la ruta del archivo de configuraciones de microsip y la SettingsKey*
            MicroSipSettings ConfigMicrosip = new MicroSipSettings();
            ConfigMicrosip.FileName = Environment.CurrentDirectory + "\\conf\\microsip.set";
            ConfigMicrosip.Key = "C0RR4L35";

            try
            {
                if (System.IO.File.Exists(ConfigMicrosip.FileName) == true)
                {
                    ConfigMicrosip = ConfigMicrosip.Deserialize<MicroSipSettings>(true);

                    ConexionMicrosip Microsip = ConfigMicrosip.Conexiones.FirstOrDefault();
                    empresa = Microsip.Empresa;
                    path = Microsip.Host;
                    user = Microsip.Usuario;
                    pass = Microsip.PassWord;
                    port = Microsip.Puerto.ToString();
                    MysqlDatabase = Microsip.BaseDatosFAE;

                    bSuccess = true;                    
                }
                else
                {
                    StringBuilder sbMensajeError = new StringBuilder();
                    sbMensajeError.AppendLine("No se encontro el archivo [Microsip.SET]...");
                    sbMensajeError.AppendLine();
                    sbMensajeError.AppendLine("Recuerde agregar los archivos .SET en la siguiente ruta:");
                    sbMensajeError.AppendLine(Environment.CurrentDirectory + "\\conf\\");

                    throw new Exception(sbMensajeError.ToString());
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                bSuccess = false;
            }

            return bSuccess;
        }
    }
}
