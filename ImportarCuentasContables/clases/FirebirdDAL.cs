using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Text.RegularExpressions;

namespace ImportarCuentasContables.clases
{
    public class FirebirdDAL
    {
        ConfiguracionMicrosip MicrosipConfig;
        FbConnection Conexion;
        FbCommand Comando;
        FbDataAdapter Adapter;

        public FirebirdDAL(ConfiguracionMicrosip MicrosipConfig)
        {
            this.MicrosipConfig = MicrosipConfig;

            Conexion = new FbConnection();
            Comando = new FbCommand();
            Adapter = new FbDataAdapter();
        }

        private string getConnectionString()
        {
            FbConnectionStringBuilder ConnectionStringBuilder = new FbConnectionStringBuilder();
            ConnectionStringBuilder.UserID = MicrosipConfig.user;
            ConnectionStringBuilder.Password = MicrosipConfig.pass;
            ConnectionStringBuilder.Port = Convert.ToInt32(MicrosipConfig.port);
            ConnectionStringBuilder.Database = MicrosipConfig.path;

            return ConnectionStringBuilder.ToString();
        }

        public bool probarConexion()
        {
            Conexion.ConnectionString = getConnectionString();
            try
            {
                Conexion.Open();
                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();

                throw ex;
            }
        }

        public void ImportarCuentaContable(int idMicroCuentaPadre, Cliente oCliente)
        {
            Conexion.ConnectionString = getConnectionString();
            try
            {
                string nombre = oCliente.Nombre;
                if (nombre.Length > 50)
                    nombre = oCliente.Nombre.Substring(0, 50);

                Conexion.Open();
                Comando = new FbCommand(string.Empty, Conexion);
                Comando.CommandText =
                    string.Format(@"INSERT INTO CUENTAS_CO
                                       (CUENTA_ID, CUENTA_PADRE_ID, SUBCUENTA, NOMBRE)
                                    VALUES
                                       ( -1, {0}, {1}, '{2}' )", 
                                       idMicroCuentaPadre ,oCliente.iConsecutivo, nombre);
                Comando.CommandText = Regex.Replace(Comando.CommandText, @"[\r\n\x00\x1a\\'""]", @"\$0");
                Comando.ExecuteNonQuery();

                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();
            }
            catch (Exception ex)
            {
                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();

                throw ex;
            }
        }
    }
}
