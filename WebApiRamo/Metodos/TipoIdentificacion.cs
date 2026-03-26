using AccesoDatos;
using System;
using System.Data;
using System.Xml;

namespace WebApiRamo.Metodos
{
    public class TipoIdentificacion
    {
        public DataTable ConsultaTipoIdentificacion()
        {
            DataTable dataTable;
            DataTable dataTable1 = new DataTable();
            try
            {
                ClsAccesoDatos clsAccesoDato = new ClsAccesoDatos();
                XmlDocument xmlDocument = new XmlDocument();
                clsAccesoDato.ProcedimientoAlmacenado = "[dbo].[Consulta_TipoIdentificacion_Ramo]";
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