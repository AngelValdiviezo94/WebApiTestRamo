using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace WebApiRamo.Metodos
{
    public class Producto
    {
        public DataTable ConsultaProductos()
        {
            DataTable dataTable;
            DataTable dataTable1 = new DataTable();
            try
            {
                ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
                XmlDocument xmlDocument = new XmlDocument();
                clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Consulta_Productos_Ramo]";
                xmlDocument.LoadXml("<Respuesta />");
                dataTable = clsAccesoDato.ConsultarDataTable();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return dataTable;
        }

        public int GuardaListaProductos(List<cl_Producto> LstClientes, ref string numError, ref string msgError)
        {
            int num = 0;
            ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                if ((LstClientes == null ? false : LstClientes.Count > 0))
                {
                    clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Registra_Lista_Producto_Ramo]";
                    xmlDocument.LoadXml("<Producto />");
                    foreach (cl_Producto objClient in LstClientes)
                    {
                        XmlElement xmlElement = xmlDocument.CreateElement("ElementProducto");
                        
                        xmlElement.SetAttribute("IdTipoProducto", objClient.IdTipoProducto.ToString());
                        xmlElement.SetAttribute("Codigo", objClient.Codigo);
                        xmlElement.SetAttribute("Nombre", objClient.Nombre);
                        xmlElement.SetAttribute("PrecioUnitario", objClient.PrecioUnitario);
                        xmlElement.SetAttribute("Stock", objClient.Stock + "");                        
                        xmlElement.SetAttribute("UsuarioCreacion", objClient.UsuarioCreacion);
                        
                        xmlDocument.DocumentElement.AppendChild(xmlElement);
                    }
                    clsAccesoDato.AgregarParametro("@LstProducto", SqlDbType.Xml, xmlDocument.OuterXml);
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

        public int ModificaProducto(cl_Producto ObjCliente, ref string NumError, ref string MsgError)
        {
            int num = 0;
            ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                using (SqlCommand sqlCommand = ClsConexion.CrearConexion())
                {
                    clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Edita_Producto_Ramo]";
                    xmlDocument.LoadXml("<Peticion />");
                    xmlDocument.DocumentElement.SetAttribute("IdProducto", ObjCliente.Id.ToString() ?? "");
                    xmlDocument.DocumentElement.SetAttribute("IdTipoProducto", ObjCliente.IdTipoProducto.ToString() ?? "");
                    xmlDocument.DocumentElement.SetAttribute("Codigo", ObjCliente.Codigo);
                    xmlDocument.DocumentElement.SetAttribute("Nombre", ObjCliente.Nombre);
                    xmlDocument.DocumentElement.SetAttribute("PrecioUnitario", ObjCliente.PrecioUnitario);
                    xmlDocument.DocumentElement.SetAttribute("Stock", ObjCliente.Stock.ToString());                    
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

        public int EliminaProducto(int IdProducto, ref string NumError, ref string MsgError)
        {
            int num = 0;
            ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                using (SqlCommand sqlCommand = ClsConexion.CrearConexion())
                {
                    clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Elimina_Producto_Ramo]";
                    xmlDocument.LoadXml("<Peticion />");
                    xmlDocument.DocumentElement.SetAttribute("IdProducto", IdProducto.ToString() ?? "0");

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