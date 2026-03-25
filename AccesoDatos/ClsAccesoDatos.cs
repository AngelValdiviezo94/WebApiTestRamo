using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AccesoDatos
{
    public class ClsAccesoDatos
    {
        private SqlConnection sqlConexion = null;
        public string CadenaConexion = "";
        private SqlCommand sqlComando = null;
        private Dictionary<string, string> Salidas;

        public string ProcedimientoAlmacenado { get; set; }

        public ClsAccesoDatos(string cadenaConnexion)
        {
            CadenaConexion = cadenaConnexion;
            this.sqlConexion = new SqlConnection(CadenaConexion);
            this.sqlComando = new SqlCommand
            {
                Connection = this.sqlConexion,
                CommandType = CommandType.StoredProcedure
            };

        }

        public ClsAccesoDatos()
        {
            this.CadenaConexion = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            this.sqlConexion = new SqlConnection(this.CadenaConexion);
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = this.sqlConexion,
                CommandType = CommandType.StoredProcedure
            };
            this.sqlComando = sqlCommand;
        }

        public void AgregarParametro(string Nombre, SqlDbType Tipo, object Valor)
        {
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = Nombre,
                SqlDbType = Tipo,
                Value = Valor
            };
            this.sqlComando.Parameters.Add(sqlParameter);
        }

        public void AgregarParametro(string Nombre, SqlDbType Tipo, object Valor, int Tamano)
        {
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = Nombre,
                SqlDbType = Tipo,
                Value = Valor,
                Size = Tamano
            };
            this.sqlComando.Parameters.Add(sqlParameter);
        }

        public void AgregarParametroDeSalida(string Nombre, SqlDbType Tipo)
        {
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = Nombre,
                SqlDbType = Tipo,
                Direction = ParameterDirection.Output
            };
            this.sqlComando.Parameters.Add(sqlParameter);
        }

        public void AgregarParametroDeSalida(string Nombre, SqlDbType Tipo, int Tamano)
        {
            SqlParameter sqlParametros = new SqlParameter
            {
                ParameterName = Nombre,
                SqlDbType = Tipo,
                Size = Tamano,
                Direction = ParameterDirection.Output
            };
            this.sqlComando.Parameters.Add(sqlParametros);
        }

        private void LlenarParametrosDeSalida()
        {
            this.Salidas = new Dictionary<string, string>();
            if (this.sqlComando.Parameters != null)
            {
                foreach (SqlParameter sqlParametros in this.sqlComando.Parameters)
                {
                    if (sqlParametros.Direction == ParameterDirection.Output | sqlParametros.Direction == ParameterDirection.InputOutput)
                    {
                        this.Salidas.Add(sqlParametros.ParameterName, sqlParametros.Value.ToString());
                    }
                }
            }
        }

        public int Ejecutar()
        {
            int Resultado = 0;
            try
            {
                this.sqlConexion.Open();
                this.sqlComando.CommandText = this.ProcedimientoAlmacenado;
                Resultado = this.sqlComando.ExecuteNonQuery();
                this.LlenarParametrosDeSalida();
                this.sqlConexion.Close();
            }
            catch (Exception ex)
            {
                Resultado = -1;
                throw new Exception(ex.Message);
            }
            finally
            {
                try
                {
                    this.sqlConexion.Close();
                }
                catch
                {

                }
            }
            return Resultado;
        }

        public DataSet ConsultarDataSet()
        {
            try
            {
                this.sqlConexion.Open();
                this.sqlComando.CommandText = this.ProcedimientoAlmacenado;
                DataSet Resultado = new DataSet();
                SqlDataAdapter sqlData = new SqlDataAdapter(this.sqlComando);
                sqlData.Fill(Resultado);
                this.LlenarParametrosDeSalida();
                this.sqlConexion.Close();
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                try
                {
                    this.sqlConexion.Close();
                }
                catch
                { }
            }
        }

        public DataTable ConsultarDataTable()
        {
            try
            {
                var Eval = this.ConsultarDataSet();
                DataTable dataTable = new DataTable();
                if (Eval.Tables.Count > 0)
                {
                    dataTable = Eval.Tables[0];
                }
                return dataTable;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                try
                {
                    this.sqlConexion.Close();
                }
                catch
                { }
            }
        }

        public string LeerParametroDeSalida(string Nombre)
        {
            if (this.Salidas == null)
            {
                return string.Empty;
            }
            if (this.Salidas.ContainsKey(Nombre))
            {
                return this.Salidas[Nombre];
            }
            return string.Empty;
        }

    }
}
