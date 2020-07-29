using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace Utils
{
    public class adoDAL
    {
        private DbCommand _cmd;
        private DbConnection _conn;
        private DbTransaction _tran;
        private DbProviderFactory _factory;

        public DbCommand Comando { get { return _cmd; } set { _cmd = value; } }
        public DbConnection Conexion { get { return _conn; } set { _conn = value; } }
        public DbTransaction Transaccion { get { return _tran; } set { _tran = value; } }
        public DbParameter Parametro { get; set; }

        public DbProviderFactory Proveedor { get { return _factory; } set { _factory = value; } }


        string _strConn, _proveedor;

        public string ConexionBD { get { return _strConn; } set { _strConn = value; } }
        public string ProveedorBD { get { return _proveedor; } set { _proveedor = value; } }
        public string StrConnBD { get; set; }


        public adoDAL()
        {
            ConfigurarBD(StrConnBD);
        }
        public adoDAL(string DB)
        {
            this.StrConnBD = DB;
            ConfigurarBD(StrConnBD);
        }

        private void ConfigurarBD(string DB)
        {
            if (DB == null || DB == String.Empty)
            {
                StrConnBD = "Q26";
            }
            _proveedor = ConfigurationManager.ConnectionStrings[StrConnBD].ProviderName;
            _strConn = ConfigurationManager.ConnectionStrings[StrConnBD].ConnectionString;
            _factory = SqlClientFactory.Instance;

        }
        public void Conectar()
        {

            if (Conexion == null)
            {
                Conexion = _factory.CreateConnection();
                Conexion.ConnectionString = ConexionBD;
            }
            Conexion.Open();

        }
        public void Desconectar()
        {
            if (Conexion != null && Conexion.State.Equals(ConnectionState.Open))
                Conexion.Close();
        }
        public void CrearComando(string consulta)
        {
            _cmd = _factory.CreateCommand();
            _cmd.Connection = Conexion;
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = consulta;
            _cmd.CommandTimeout = 500000;

        }
        public void CrearComandoProcedure(string nomProc)
        {
            _cmd = _factory.CreateCommand();
            _cmd.Connection = Conexion;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = nomProc;
            _cmd.CommandTimeout = 500000;

        }

        public DbDataReader EjecutarConsulta()
        {
            return _cmd.ExecuteReader();
        }
        public int ExecuteNonQuery()
        {
            return _cmd.ExecuteNonQuery();
        }

        public void AgregarParametroComando(string NombreParametro, object Value, ParameterDirection P)
        {
            if (ProveedorBD.Equals("SqlClient"))
            {
                this.Parametro = new SqlParameter();
                this.Parametro.ParameterName = NombreParametro;
                this.Parametro.Value = Value;
                this.Parametro.Direction = P;
                this.Comando.Parameters.Add(Parametro);

            }
        }
        public void AgregarParametroComando(string NombreParametro, object Value, ParameterDirection P, int Size)
        {
            if (ProveedorBD.Equals("SqlClient"))
            {
                this.Parametro = new SqlParameter();
                this.Parametro.ParameterName = NombreParametro;
                this.Parametro.Value = Value;
                this.Parametro.Direction = P;
                this.Parametro.Size = Size;
                this.Comando.Parameters.Add(Parametro);

            }
        }
        public void AgregarParametroComando(string NombreParametro, object Value)
        {
            if (ProveedorBD.Equals("SqlClient"))
            {
                this.Parametro = new SqlParameter();
                this.Parametro.ParameterName = NombreParametro;
                this.Parametro.Value = Value;
                this.Comando.Parameters.Add(Parametro);
            }
        }
        public void AgregarParametroComandoFecha(string NombreParametro, DateTime Value, string type)
        {
            if (ProveedorBD.Equals("SqlClient"))
            {

                this.Parametro = new SqlParameter();
                this.Parametro.ParameterName = NombreParametro;
                if (type == "1")
                {
                    this.Parametro.Value = Value.Year + "/" + Value.Month + "/" + Value.Day;
                }
                else if (type == "2")
                {
                    this.Parametro.Value = Value.Month + "/" + Value.Day + "/" + Value.Year;
                }
                else if (type == "3")
                {
                    this.Parametro.Value = Value.Month + "/" + Value.Day + "/" + Value.Year + " " + Value.Hour + ":" + Value.Minute + ":00";
                }
                this.Comando.Parameters.Add(Parametro);

            }
        }

        public DataSet getDataSet()
        {
            DataSet ds = new DataSet();
            System.Data.IDbDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            dataAdapter.SelectCommand = _cmd;
            dataAdapter.Fill(ds);

            return ds;
        }
    }


}