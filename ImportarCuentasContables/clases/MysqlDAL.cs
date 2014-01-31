using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace ImportarCuentasContables.clases
{
    public class MysqlDAL
    {
        ConfiguracionMysql MysqlConfig;
        MySqlConnection Conexion;
        MySqlCommand Comando;
        MySqlDataAdapter Adapter;
        
        public MysqlDAL(ConfiguracionMysql MysqlConfig)
        {
            this.MysqlConfig = MysqlConfig;

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
            StringConnectionBuilder.Database = MysqlConfig.database;

            return StringConnectionBuilder.ToString();
        }

        public ConfiguracionMicrosip getDatosMicrosip(string sucursal, string tipoConexion)
        {
            Conexion.ConnectionString = getConnectionString();
            try
            {
                Conexion.Open();
                Comando = new MySqlCommand(string.Empty, Conexion);
                Comando.CommandText =
                    string.Format(@"SELECT 
                                        c.idconteo,
                                        sucursal,
                                        md.database,
                                        usuario,
                                        contraseña as pass,
                                        puerto,
                                        tipo
                                    FROM
                                        conteos c
                                            INNER JOIN
                                        microsip_datos md ON md.id_conteo = c.idconteo
                                    Where
                                        sucursal = '{0}' AND tipo = '{1}'",
                                        sucursal, tipoConexion);

                ConfiguracionMicrosip MicrosipConfig = new ConfiguracionMicrosip();
                Adapter = new MySqlDataAdapter();

                DataTable dtResultado = new DataTable();
                Adapter.SelectCommand = Comando;
                Adapter.Fill(dtResultado);

                foreach(DataRow row in dtResultado.Rows)
                {
                    MicrosipConfig.empresa = sucursal;
                    MicrosipConfig.user = Convert.ToString(row["usuario"]);
                    MicrosipConfig.pass = Convert.ToString(row["pass"]);
                    MicrosipConfig.path = Convert.ToString(row["database"]);
                    MicrosipConfig.port = Convert.ToString(row["puerto"]);
                }

                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();

                return MicrosipConfig;
            }
            catch (Exception ex)
            {
                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();
                throw ex;
            }
        }

        public List<Conteo> getConteos()
        {
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
                                        conteos");
                Adapter = new MySqlDataAdapter();

                DataTable dtResultado = new DataTable();
                Adapter.SelectCommand = Comando;
                Adapter.Fill(dtResultado);


                Conteo conteo;
                List<Conteo> lstConteos = new List<Conteo>();
                foreach (DataRow row in dtResultado.Rows)
                {
                    conteo = new Conteo();
                    conteo.IdConteo = Convert.ToInt32(row["idconteo"]);
                    conteo.CuentaPadre = Convert.ToString(row["cuentapadre"]);
                    conteo.IdMicroCuentaPadre = Convert.ToInt32(row["idmicrocuentapadre"]);
                    conteo.iConteo = Convert.ToInt32(row["conteo"]);
                    conteo.Sucursal = Convert.ToString(row["sucursal"]);
                    conteo.Status = Convert.ToBoolean(row["status"]);
                    lstConteos.Add(conteo);
                }

                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();

                return lstConteos;
            }
            catch (Exception ex)
            {
                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();
                throw ex;
            }
        }

        public List<string> getTiposConexion()
        {
            Conexion.ConnectionString = getConnectionString();
            try
            {
                Conexion.Open();
                Comando = new MySqlCommand(string.Empty, Conexion);
                Comando.CommandText =
                    string.Format(@"SELECT DISTINCT
                                        tipo
                                    FROM
                                        microsip_datos ");
                Adapter = new MySqlDataAdapter();

                DataTable dtResultado = new DataTable();
                Adapter.SelectCommand = Comando;
                Adapter.Fill(dtResultado);

                string tipo;
                List<string> lstTipos = new List<string>();
                foreach (DataRow row in dtResultado.Rows)
                {
                    tipo = Convert.ToString(row["tipo"]);
                    lstTipos.Add(tipo);
                }

                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();

                return lstTipos;
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
