using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace CuentasContablesClientesSrc.clases
{
    public class MysqlDAL
    {
        ConfiguracionMicrosip MicrosipConfig;
        ConfiguracionMysql MysqlConfig;
        MySqlConnection Conexion;
        MySqlCommand Comando;
        MySqlDataAdapter Adapter;
        
        public MysqlDAL(ConfiguracionMysql MysqlConfig, ConfiguracionMicrosip MicrosipConfig)
        {
            this.MysqlConfig = MysqlConfig;
            this.MicrosipConfig = MicrosipConfig;

            Conexion = new MySqlConnection();
            Comando = new MySqlCommand();
            Adapter = new MySqlDataAdapter();
            
        }

        private string getConnectionString()
        {
            MySqlConnectionStringBuilder 
                StringConnectionBuilder = new MySqlConnectionStringBuilder();

            StringConnectionBuilder.Server = MysqlConfig.server;
            StringConnectionBuilder.UserID = MysqlConfig.user;
            StringConnectionBuilder.Password = MysqlConfig.pass;
            StringConnectionBuilder.Database = MicrosipConfig.MysqlDatabase;

            return StringConnectionBuilder.ToString();
        }

        public int getUltimoConteo()
        {
            string empresa = MicrosipConfig.empresa.ToLower();

            Conexion.ConnectionString = getConnectionString();
            try
            {
                Conexion.Open();
                Comando = new MySqlCommand(string.Empty, Conexion);
                Comando.CommandText =
                    string.Format(@"SELECT 
                                    conteo 
                                  FROM 
                                    conteos 
                                 WHERE 
                                    sucursal='{0}' and status=1", empresa);

                object objResultado = Comando.ExecuteScalar();
                int iUltimoConteo = Convert.ToInt32(objResultado);

                return iUltimoConteo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();
            }
        }
    }
}
