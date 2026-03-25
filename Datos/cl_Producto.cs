
namespace Datos
{
    public class cl_Producto
    {
        public int Id { get; set; }
        
		public int IdTipoProducto { get; set; }

        public string Codigo { get; set; }
        
		public string Nombre { get; set; }

		public string PrecioUnitario { get; set; }
		
		public string Estado { get; set; }
		
		public int Stock { get; set; }
		
		public string UsuarioCreacion { get; set; }
		
		public string UsuarioModificacion { get; set; }
    }
}
