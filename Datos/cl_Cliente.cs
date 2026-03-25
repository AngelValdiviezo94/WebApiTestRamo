using System;

namespace Datos
{
    public class cl_Cliente
    {
        public int Id { get; set; }
        
        public string Nombres { get; set; }
        
        public string Apellidos { get; set; }
        
        public string RazonSocial { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        public int IdTipoIdentificacion { get; set; }

        public string NumIdentificacion { get; set; }
        
        public string Telefono { get; set; }
        
        public string Direccion { get; set; }
        
        public string Email { get; set; }

        public string EstadoCivil { get; set; }
        
        public string TendenciaCompra { get; set; }
        
        public string UsuarioCreacion { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime? Fecha_Modificacion { get; set; }
    }
}
