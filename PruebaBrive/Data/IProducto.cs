using PruebaBrive.Models;

namespace PruebaBrive.Data
{
    public interface IProducto
    {
        IEnumerable<Producto> ObtenerProductos();
        Producto ObtenerProductoid(int id);

        void InsertarProducto(Producto producto);
        void ActulizarProducto(Producto producto);
        void EliminarProducto(int id);
    }
}
