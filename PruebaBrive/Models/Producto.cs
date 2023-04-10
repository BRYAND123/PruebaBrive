namespace PruebaBrive.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Descripcion { get; set; }
        public string? Marca { get; set; }
        public string? Cantidad { get; set;}
        public decimal Precio { get; set;}

    }
}
