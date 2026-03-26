using System;

namespace Datos
{
    public class cl_Tipo_Producto
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        
        public bool Activo { get; set; }

        public string UsuarioCreacion { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime? Fecha_Modificacion { get; set; }
    }
}
