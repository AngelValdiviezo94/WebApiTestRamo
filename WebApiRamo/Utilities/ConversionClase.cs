using Datos;
using Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApiRamo.Utilities
{
    public class ConversionClase
    {
        #region Clientes
        public List<cl_Cliente> ListaCliente(DataTable dataTable)
        {
            cl_Cliente ObjCliente = new cl_Cliente();
            List<cl_Cliente> LstClientes = new List<cl_Cliente>();

            foreach (DataRow row in dataTable.Rows)
            {
                ObjCliente.Id = Convert.ToInt16(row["Id"].ToString());

                ObjCliente.Nombres = row["Nombres"].ToString();
                ObjCliente.Apellidos = row["Apellidos"].ToString();
                ObjCliente.RazonSocial = row["RazonSocial"].ToString();
                ObjCliente.Fecha_Nacimiento = Convert.ToDateTime(row["FechaNacimiento"].ToString());
                ObjCliente.NumIdentificacion = row["NumIdentificacion"].ToString();
                ObjCliente.Telefono = row["Telefono"].ToString();
                ObjCliente.Direccion = row["Direccion"].ToString();
                ObjCliente.Email = row["Email"].ToString();
                ObjCliente.TendenciaCompra = row["TendenciaCompra"].ToString();

                LstClientes.Add(ObjCliente);
                ObjCliente = new cl_Cliente();
            }

            return LstClientes;
        }

        #endregion

        #region Productos
        public List<cl_Producto> ListaProductos(DataTable dataTable)
        {
            cl_Producto ObjCliente = new cl_Producto();
            List<cl_Producto> LstClientes = new List<cl_Producto>();

            foreach (DataRow row in dataTable.Rows)
            {
                ObjCliente.Id = Convert.ToInt16(row["Id"].ToString());

                ObjCliente.Nombre = row["Nombre"].ToString();
                ObjCliente.Codigo = row["Codigo"].ToString();
                ObjCliente.PrecioUnitario = row["PrecioUnitario"].ToString();
                ObjCliente.IdTipoProducto = Convert.ToInt16(row["Id_TipoProducto"].ToString());
                ObjCliente.Estado = row["Estado"].ToString();
                ObjCliente.Stock = Convert.ToInt16(row["Stock"].ToString());
                
                LstClientes.Add(ObjCliente);
                ObjCliente = new cl_Producto();
            }

            return LstClientes;
        }

        #endregion


        public void RegistraLogError(Exception excepcion)
        {
            ClasLog logError = new ClasLog();
            string mensajeExcepcion = excepcion.Message;

            logError.GrabaLogError(mensajeExcepcion);
        }

        public RespuestaModelo LlenaRespuestaModeloError(Exception excepcion)
        {
            RespuestaModelo respuestaModelo = new RespuestaModelo();

            RegistraLogError(excepcion);

            respuestaModelo.MensajeError = string.Concat(excepcion.Message, " ", excepcion.Source);
            respuestaModelo.DetalleError = Convert.ToString(excepcion.StackTrace).Trim();
            respuestaModelo.ProcesoExitoso = false;
            respuestaModelo.Respuesta = null;

            return respuestaModelo;

        }

    }
}