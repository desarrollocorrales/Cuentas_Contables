using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccSettings;

namespace CuentasContablesClientesSrc.clases
{
    public class ConfiguracionMysql
    {
        public string server { get; set; }
        public string database { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public string port { get; set; }
        public string errorMessage { set; get; }

        public bool LoadConfiguration()
        {
            bool bSuccess = false;

            //Obtener la ruta del archivo de configuraciones de microsip y la SettingsKey*
            DBMSSettings ConfigMysql = new DBMSSettings();
            ConfigMysql.FileName = Environment.CurrentDirectory + "\\conf\\dbms.set";
            ConfigMysql.Key = "C0RR4L35";

            try
            {
                if (System.IO.File.Exists(ConfigMysql.FileName) == true)
                {
                    ConfigMysql = ConfigMysql.Deserialize<DBMSSettings>(true);

                    DBMS Mysql = ConfigMysql.Dbms.FirstOrDefault();
                    server = Mysql.Host;
                    user = Mysql.Usuario;
                    pass = Mysql.Pwd;
                    port = Mysql.Puerto.ToString();

                    bSuccess = true;
                }
                else
                {
                    StringBuilder sbMensajeError = new StringBuilder();
                    sbMensajeError.AppendLine("No se encontro el archivo [Dbms.SET]...");
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
