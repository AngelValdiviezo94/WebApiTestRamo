using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApiRamo.Utilities
{
    public class ConversionClase
    {
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
    }
}