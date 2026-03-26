using Datos;
using Logger;
using System;
using System.Collections.Generic;
using System.Data;

namespace WebApiRamo.Utilities
{
    public class ConversionClase
    {
        #region Usuario
        public cl_Usuario UserConvert(DataTable dataTable)
        {
            cl_Usuario ObjCliente = new cl_Usuario();
            //List<cl_Producto> LstClientes = new List<cl_Producto>();

            foreach (DataRow row in dataTable.Rows)
            {
                ObjCliente.Id = Convert.ToInt16(row["Id"].ToString());

                ObjCliente.Activo = Convert.ToBoolean(row["Activo"].ToString());
                ObjCliente.UserName = row["UserName"].ToString();                
                ObjCliente.PassWord = row["PassWord"].ToString();                
            }

            return ObjCliente;
        }

        #endregion
        #region Clientes
        public cl_Cliente ObjCliente(DataTable dataTable)
        {
            cl_Cliente ObjCliente = new cl_Cliente();
            //List<cl_Cliente> LstClientes = new List<cl_Cliente>();

            foreach (DataRow row in dataTable.Rows)
            {
                ObjCliente.Id = Convert.ToInt16(row["Id"].ToString());

                ObjCliente.Nombres = row["Nombres"].ToString();
                ObjCliente.Apellidos = row["Apellidos"].ToString();
                ObjCliente.RazonSocial = row["RazonSocial"].ToString();
                ObjCliente.Fecha_Nacimiento = Convert.ToDateTime(row["FechaNacimiento"].ToString());
                ObjCliente.NumIdentificacion = row["NumIdentificacion"].ToString();
                ObjCliente.IdTipoIdentificacion = Convert.ToInt16(row["Id_TipoIdentificacion"].ToString());
                ObjCliente.EstadoCivil = Convert.ToInt16(row["EstadoCivil"].ToString());
                ObjCliente.Telefono = row["Telefono"].ToString();
                ObjCliente.Direccion = row["Direccion"].ToString();
                ObjCliente.Email = row["Email"].ToString();
                ObjCliente.TendenciaCompra = Convert.ToInt16(row["TendenciaCompra"].ToString());
            }

            return ObjCliente;
        }

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
                ObjCliente.TendenciaCompra = Convert.ToInt16(row["TendenciaCompra"].ToString());
                //ObjCliente.EstadoCivil = Convert.ToInt16(row["EstadoCivil"].ToString());

                LstClientes.Add(ObjCliente);
                ObjCliente = new cl_Cliente();
            }

            return LstClientes;
        }
        #endregion

        #region Productos
        public cl_Producto ObjProducto(DataTable dataTable)
        {
            cl_Producto ObjCliente = new cl_Producto();
            //List<cl_Producto> LstClientes = new List<cl_Producto>();

            foreach (DataRow row in dataTable.Rows)
            {
                ObjCliente.Id = Convert.ToInt16(row["Id"].ToString());

                ObjCliente.Nombre = row["Nombre"].ToString();
                ObjCliente.Codigo = row["Codigo"].ToString();
                ObjCliente.PrecioUnitario = row["PrecioUnitario"].ToString();
                ObjCliente.IdTipoProducto = Convert.ToInt16(row["Id_TipoProducto"].ToString());
                ObjCliente.Estado = row["Estado"].ToString();
                ObjCliente.Stock = Convert.ToInt16(row["Stock"].ToString());                
            }

            return ObjCliente;
        }
        
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

        #region Tipo Producto
        
        public List<cl_Tipo_Producto> ListaTipoProducto(DataTable dataTable)
        {
            cl_Tipo_Producto ObjCliente = new cl_Tipo_Producto();
            List<cl_Tipo_Producto> LstClientes = new List<cl_Tipo_Producto>();

            foreach (DataRow row in dataTable.Rows)
            {
                ObjCliente.Id = Convert.ToInt16(row["Id"].ToString());
                ObjCliente.Nombre = row["Nombre"].ToString();
                //ObjCliente.Activo = Convert.ToBoolean(row["Codigo"].ToString());
                
                LstClientes.Add(ObjCliente);
                ObjCliente = new cl_Tipo_Producto();
            }

            return LstClientes;
        }
        #endregion

        #region Tipo Identificación

        public List<cl_Tipo_Identificacion> ListaTipoIdentificacion(DataTable dataTable)
        {
            cl_Tipo_Identificacion ObjCliente = new cl_Tipo_Identificacion();
            List<cl_Tipo_Identificacion> LstClientes = new List<cl_Tipo_Identificacion>();

            foreach (DataRow row in dataTable.Rows)
            {
                ObjCliente.Id = Convert.ToInt16(row["Id"].ToString());
                ObjCliente.Nombre = row["Descripcion"].ToString();
                //ObjCliente.Activo = Convert.ToBoolean(row["Codigo"].ToString());

                LstClientes.Add(ObjCliente);
                ObjCliente = new cl_Tipo_Identificacion();
            }

            return LstClientes;
        }
        #endregion

        #region Estado Civil

        public List<cl_EstadoCivil> ListaEstadoCivil(DataTable dataTable)
        {
            cl_EstadoCivil ObjCliente = new cl_EstadoCivil();
            List<cl_EstadoCivil> LstClientes = new List<cl_EstadoCivil>();

            foreach (DataRow row in dataTable.Rows)
            {
                ObjCliente.Id = Convert.ToInt16(row["Id"].ToString());
                ObjCliente.Nombre = row["Descripcion"].ToString();
                //ObjCliente.Activo = Convert.ToBoolean(row["Codigo"].ToString());

                LstClientes.Add(ObjCliente);
                ObjCliente = new cl_EstadoCivil();
            }

            return LstClientes;
        }
        #endregion

        #region Carrito 
        public cl_CarritoCab ListaCarrito(DataTable dataTable)
        {
            cl_CarritoCab ObjCarrito = new cl_CarritoCab();
            List<cl_CarritoDet> LstDet = new List<cl_CarritoDet>();
            cl_CarritoDet ObjDet = new cl_CarritoDet();

            foreach (DataRow row in dataTable.Rows)
            {
                ObjDet.IdProd = Convert.ToInt16(row["IdProducto"].ToString());
                
                ObjDet.NombreProd = row["NombreProducto"].ToString();
                ObjDet.CodProd = row["CodigoProducto"].ToString();
                ObjDet.Cantidad = Convert.ToInt16(row["Cantidad"].ToString());
                ObjDet.PrecioUnitario = Convert.ToDouble(row["PrecioUnitario"].ToString());                

                LstDet.Add(ObjDet);
                ObjDet = new cl_CarritoDet();
            }
            ObjCarrito.LstCarritoDet = LstDet;        
            return ObjCarrito;
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