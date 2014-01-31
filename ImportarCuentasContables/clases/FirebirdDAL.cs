using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

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

        public List<Cliente> getClientesSinCuentaCo()
        {
            Conexion.ConnectionString = getConnectionString();
            try
            {
                Conexion.Open();
                Comando = new FbCommand(string.Empty, Conexion);
                Comando.CommandText =
                    string.Format(@"  SELECT 
                                          CLIENTE_ID, NOMBRE, CUENTA_CXC 
                                        FROM 
                                          CLIENTES 
                                       WHERE 
                                          CUENTA_CXC IS NULL 
                                    ORDER BY 
                                          CLIENTE_ID");

                DataTable tbResultado = new DataTable();
                Adapter.SelectCommand = Comando;
                Adapter.Fill(tbResultado);

                Cliente oCliente;
                List<Cliente> lstClientes = new List<Cliente>();
                foreach (DataRow row in tbResultado.Rows)
                {
                    oCliente = new Cliente();
                    oCliente.ID = Convert.ToInt32(row["CLIENTE_ID"]);
                    oCliente.Nombre = Convert.ToString(row["NOMBRE"]);
                    oCliente.Cuenta_CO = Convert.ToString(row["CUENTA_CXC"]);
                    lstClientes.Add(oCliente);
                }

                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();

                return lstClientes;
            }
            catch (Exception ex)
            {
                if (Conexion.State != System.Data.ConnectionState.Closed)
                    Conexion.Close();

                throw ex;
            }
        }

        public void ActualizarCliente(Cliente cliente)
        {
            Conexion.ConnectionString = getConnectionString();
            try
            {
                Conexion.Open();
                Comando = new FbCommand(string.Empty, Conexion);
                Comando.CommandText =
                    string.Format(@"UPDATE CLIENTES 
                                       SET CUENTA_CXC = '{0}' 
                                     WHERE CLIENTE_ID = {1}",
                                     cliente.Cuenta_CO, 
                                     cliente.ID);
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

        public void InsertarCuentaContable(Cliente cliente)
        {
            Conexion.ConnectionString = getConnectionString();
            try
            {
                Conexion.Open();
                Comando = new FbCommand(string.Empty, Conexion);
                Comando.CommandText =
                    string.Format(@"INSERT INTO CUENTAS_CO 
                                       (CUENTA_ID, CUENTA_PADRE_ID, SUBCUENTA)
                                    VALUES
                                       (-1, {0},{1})",
                                     cliente.ID,
                                     cliente.iConsecutivo);
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
