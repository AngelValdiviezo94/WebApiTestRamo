using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace WebApiRamo.Metodos
{
    public class TipoProducto
    {
        public DataTable ConsultaTipoProductos()
        {
            DataTable dataTable;
            DataTable dataTable1 = new DataTable();
            try
            {
                ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
                XmlDocument xmlDocument = new XmlDocument();
                clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Consulta_TipoProductos_Ramo]";
                xmlDocument.LoadXml("<Respuesta />");
                dataTable = clsAccesoDato.ConsultarDataTable();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return dataTable;
        }

    }
}