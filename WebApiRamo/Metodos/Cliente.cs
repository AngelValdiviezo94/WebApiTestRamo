using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace WebApiRamo.Metodos
{
    public class Cliente
    {
        public DataTable ConsultaClientes()
        {
            DataTable dataTable;
            DataTable dataTable1 = new DataTable();
            try
            {
                ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
                XmlDocument xmlDocument = new XmlDocument();
                clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Consulta_Clientes_Ramo]";
                xmlDocument.LoadXml("<Respuesta />");
                dataTable = clsAccesoDato.ConsultarDataTable();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return dataTable;
        }

        public DataTable ConsultaClienteById(string IdCli)
        {
            DataTable dataTable;
            DataTable dataTable1 = new DataTable();
            try
            {
                ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
                XmlDocument xmlDocument = new XmlDocument();
                clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Consulta_Cliente_ById_Ramo]";
                xmlDocument.LoadXml("<Respuesta />");
                clsAccesoDato.AgregarParametro("@IdCliente", SqlDbType.NVarChar, IdCli);
                dataTable = clsAccesoDato.ConsultarDataTable();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return dataTable;
        }


        public int GuardaListaClientes(List<cl_Cliente> LstClientes, ref string numError, ref string msgError)
        {
            int num = 0;
            ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                if ((LstClientes == null ? false : LstClientes.Count > 0))
                {
                    clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Registra_Lista_Cliente_Ramo]";
                    xmlDocument.LoadXml("<Cliente />");
                    foreach (cl_Cliente objClient in LstClientes)
                    {
                        XmlElement xmlElement = xmlDocument.CreateElement("ElementCliente");
                        //int idPersona = lstPersona.Id;
                        xmlElement.SetAttribute("Nombres", objClient.Nombres);
                        xmlElement.SetAttribute("Apellidos", objClient.Apellidos);
                        xmlElement.SetAttribute("RazonSocial", objClient.RazonSocial);
                        xmlElement.SetAttribute("NumIdentificacion", objClient.NumIdentificacion);
                        xmlElement.SetAttribute("Direccion", objClient.Direccion);
                        xmlElement.SetAttribute("Email", objClient.Email);
                        xmlElement.SetAttribute("FechaNacimiento", objClient.Fecha_Nacimiento.ToString("yyyy-MM-dd"));
                        xmlElement.SetAttribute("TendenciaCompra", objClient.TendenciaCompra);
                        xmlElement.SetAttribute("Telefono", objClient.Telefono);
                        xmlElement.SetAttribute("UsuarioCreacion", objClient.UsuarioCreacion);
                        xmlElement.SetAttribute("EstadoCivil", objClient.EstadoCivil);
                        
                        xmlDocument.DocumentElement.AppendChild(xmlElement);
                    }
                    clsAccesoDato.AgregarParametro("@LstClientes", SqlDbType.Xml, xmlDocument.OuterXml);
                    clsAccesoDato.AgregarParametroDeSalida("@MsgError", SqlDbType.VarChar, 500);
                    clsAccesoDato.AgregarParametroDeSalida("@NumError", SqlDbType.Int, 4);
                    num = clsAccesoDato.Ejecutar();
                    msgError = clsAccesoDato.LeerParametroDeSalida("@MsgError").Trim();
                    numError = clsAccesoDato.LeerParametroDeSalida("@NumError").Trim();
                    clsAccesoDato = new ClsAccesoDatos();
                    xmlDocument = new XmlDocument();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                num = -100;
                throw new Exception(exception.Message);
            }
            return num;
        }

        public int ModificaCliente(cl_Cliente ObjCliente, ref string NumError, ref string MsgError)
        {
            int num = 0;
            ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                using (SqlCommand sqlCommand = ClsConexion.CrearConexion())
                {
                    clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Edita_Cliente_Ramo]";
                    xmlDocument.LoadXml("<Peticion />");
                    xmlDocument.DocumentElement.SetAttribute("IdCliente", ObjCliente.Id.ToString() ?? "");
                    xmlDocument.DocumentElement.SetAttribute("Nombres", ObjCliente.Nombres);
                    xmlDocument.DocumentElement.SetAttribute("Apellidos", ObjCliente.Apellidos);
                    xmlDocument.DocumentElement.SetAttribute("RazonSocial", ObjCliente.RazonSocial);
                    xmlDocument.DocumentElement.SetAttribute("Direccion", ObjCliente.Direccion);
                    xmlDocument.DocumentElement.SetAttribute("Email", ObjCliente.Email);
                    xmlDocument.DocumentElement.SetAttribute("Telefono", ObjCliente.Telefono);
                    xmlDocument.DocumentElement.SetAttribute("UsuarioModificacion", ObjCliente.UsuarioModificacion);

                    clsAccesoDato.AgregarParametro("@PI_ParamXML", SqlDbType.Xml, xmlDocument.OuterXml);
                    clsAccesoDato.AgregarParametroDeSalida("@MsgError", SqlDbType.VarChar, 500);
                    clsAccesoDato.AgregarParametroDeSalida("@NumError", SqlDbType.Int, 4);
                    int num1 = clsAccesoDato.Ejecutar();
                    MsgError = clsAccesoDato.LeerParametroDeSalida("@MsgError").Trim();
                    NumError = clsAccesoDato.LeerParametroDeSalida("@NumError").Trim();
                    num = num1;
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MsgError = exception.Message;
                exception.ToString();
                num = 0;
            }
            return num;
        }

        public int EliminaCliente(int idCliente, ref string NumError, ref string MsgError)
        {
            int num = 0;
            ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                using (SqlCommand sqlCommand = ClsConexion.CrearConexion())
                {
                    clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Elimina_Cliente_Ramo]";
                    xmlDocument.LoadXml("<Peticion />");
                    xmlDocument.DocumentElement.SetAttribute("IdCliente", idCliente.ToString() ?? "0");
                    
                    clsAccesoDato.AgregarParametro("@PI_ParamXML", SqlDbType.Xml, xmlDocument.OuterXml);
                    clsAccesoDato.AgregarParametroDeSalida("@MsgError", SqlDbType.VarChar, 500);
                    clsAccesoDato.AgregarParametroDeSalida("@NumError", SqlDbType.Int, 4);
                    int num1 = clsAccesoDato.Ejecutar();
                    MsgError = clsAccesoDato.LeerParametroDeSalida("@MsgError").Trim();
                    NumError = clsAccesoDato.LeerParametroDeSalida("@NumError").Trim();
                    num = num1;
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MsgError = exception.Message;
                exception.ToString();
                num = 0;
            }
            return num;
        }

    }
}