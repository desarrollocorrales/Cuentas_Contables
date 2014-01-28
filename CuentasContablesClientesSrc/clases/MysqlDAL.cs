using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

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

                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();

                return iUltimoConteo;
            }
            catch (Exception ex)
            {
                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();
                throw ex;
            }
        }

        public void InsertCliente(Cliente cliente)
        {
            string empresa = MicrosipConfig.empresa.ToLower();

            Conexion.ConnectionString = getConnectionString();
            try
            {
                Conexion.Open();
                Comando = new MySqlCommand(string.Empty, Conexion);
                Comando.CommandText =
                    string.Format(@"INSERT INTO 
                                        {0} 
                                      (idcliente, nombre, cuenta, consecutivo, status)    
                                    VALUES 
                                      ({1}, '{2}', '{3}', {4}, 1)", 
                                    empresa, cliente.ID, cliente.Nombre, cliente.Cuenta_CO, cliente.iConsecutivo);

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

        public void UpdateConsecutivo(int iConsecutivo)
        {
            string sucursal = MicrosipConfig.empresa.ToLower();
            Conexion.ConnectionString = getConnectionString();
            try
            {
                Conexion.Open();
                Comando = new MySqlCommand(string.Empty, Conexion);
                Comando.CommandText =
                    string.Format(@"UPDATE
                                        conteos 
                                    SET
                                        conteo = {0}
                                    WHERE
                                        sucursal = '{1}'",
                                    iConsecutivo, sucursal);

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

        public Conteo getDatosSucursal()
        {
            string empresa = MicrosipConfig.empresa.ToLower();

            Conexion.ConnectionString = getConnectionString();
            try
            {
                Conexion.Open();
                Comando = new MySqlCommand(string.Empty, Conexion);
                Comando.CommandText =
                    string.Format(@"SELECT 
                                        idconteo,
                                        cuentapadre,
                                        idmicrocuentapadre,
                                        conteo,
                                        sucursal,
                                        status
                                    FROM
                                        corrales_cuentascontables.conteos
                                    WHERE
	                                    sucursal='{0}' AND status=1", 
                                    empresa);

                Conteo conteo = new Conteo();
                Adapter = new MySqlDataAdapter();

                DataTable dtResultado = new DataTable();
                Adapter.SelectCommand = Comando;
                Adapter.Fill(dtResultado);

                foreach(DataRow row in dtResultado.Rows)
                {
                    conteo.IdConteo = Convert.ToInt32(row["idconteo"]);
                    conteo.CuentaPadre = Convert.ToString(row["cuentapadre"]);
                    conteo.IdMicroCuentaPadre = Convert.ToInt32(row["idmicrocuentapadre"]);
                    conteo.iConteo = Convert.ToInt32(row["conteo"]);
                    conteo.Sucursal = Convert.ToString(row["sucursal"]);
                    conteo.Status = Convert.ToBoolean(row["status"]);
                }

                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();

                return conteo;
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
