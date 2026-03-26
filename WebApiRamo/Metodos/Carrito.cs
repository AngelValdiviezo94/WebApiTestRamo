using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace WebApiRamo.Metodos
{
    public class Carrito
    {
        public DataTable ConsultaCarrito()
        {
            DataTable dataTable;
            DataTable dataTable1 = new DataTable();
            try
            {
                ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
                XmlDocument xmlDocument = new XmlDocument();
                clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Consulta_Carrito_Ramo]";
                xmlDocument.LoadXml("<Respuesta />");
                dataTable = clsAccesoDato.ConsultarDataTable();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return dataTable;
        }

        public int GuardaListaCarrito(cl_CarritoCab CarritoCab, ref string numError, ref string msgError)
        {
            int num = 0;
            ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                if ((CarritoCab == null ? false : CarritoCab.LstCarritoDet.Count > 0))
                {
                    clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[AgregaCarrito_Ramo]";
                    xmlDocument.LoadXml("<Cliente />");
                    foreach (cl_CarritoDet item in CarritoCab.LstCarritoDet)
                    {
                        XmlElement xmlElement = xmlDocument.CreateElement("ElementCarrito");
                        //int idPersona = lstPersona.Id;
                        xmlElement.SetAttribute("IdUsuario", CarritoCab.IdUsuario + "");
                        xmlElement.SetAttribute("IdProd", item.IdProd + "");
                        xmlElement.SetAttribute("Cantidad", item.Cantidad + "");
                        xmlElement.SetAttribute("PrecioUnitario", item.PrecioUnitario + "");

                        xmlDocument.DocumentElement.AppendChild(xmlElement);
                    }
                    clsAccesoDato.AgregarParametro("@LstCarrito", SqlDbType.Xml, xmlDocument.OuterXml);
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

    }
}