
using Dapper;
using PruebaBrive.Models;
using System.Data;

namespace PruebaBrive.Data
{
    public class ProductoImple : IProducto
    {
        private readonly Conexion _conexion;
        public ProductoImple(Conexion conexion)
        {
            _conexion = conexion;
        }

        public void ActulizarProducto(Producto producto)
        {
            using(var conexion = _conexion.ObtenerConexion())

            {
                //procedimientos almacenados
                var parametros = new DynamicParameters();
                conexion.Execute("actualizarproductos", parametros, commandType: CommandType.StoredProcedure);
                parametros.Add("@IdProducto", producto.IdProducto, DbType.Int32);
                parametros.Add("@Nombre", producto.Nombre, DbType.String);
                parametros.Add("@CodigoBarra", producto.CodigoBarra, DbType.String);
                parametros.Add("@Descripcion" , producto.Descripcion, DbType.String);
                parametros.Add("@Marca", producto.Marca, DbType.String);
                parametros.Add("@Cantidad",producto.Cantidad, DbType.String);
                parametros.Add("@Precio", producto.Precio , DbType.Decimal);
               
            } 
        }

        public void EliminarProducto(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())

            {
                //procedimientos almacenados
                var parametros = new DynamicParameters();
                conexion.Execute("eliminarproductos", parametros, commandType: CommandType.StoredProcedure);
                parametros.Add("@IdProducto", id, DbType.Int32);
            }

            }

        public void InsertarProducto(Producto producto)
        {
            using (var conexion = _conexion.ObtenerConexion())

            {
                //procedimientos almacenados
                var parametros = new DynamicParameters();
                conexion.Execute("insertarproductos", parametros, commandType: CommandType.StoredProcedure);
                parametros.Add("@Nombre", producto.Nombre, DbType.String);
                parametros.Add("@CodigoBarra", producto.CodigoBarra, DbType.String);
                parametros.Add("@Descripcion", producto.Descripcion, DbType.String);
                parametros.Add("@Marca", producto.Marca, DbType.String);
                parametros.Add("@Cantidad", producto.Cantidad, DbType.String);
                parametros.Add("@Precio", producto.Precio, DbType.Decimal);
              

            }
        }

        public Producto ObtenerProductoid(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())

            {
                //procedimientos almacenados
                var parametros = new DynamicParameters();
               return conexion.QueryFirstOrDefault<Producto>("ObtenerProductoid", parametros, commandType: CommandType.StoredProcedure);
                parametros.Add("@IdProducto", id, DbType.Int32);
               

            }
        }

        public IEnumerable<Producto> ObtenerProductos()
        {
            using (var conexion = _conexion.ObtenerConexion())

            {
                //procedimientos almacenados
                
                return conexion.Query<Producto>("ObtenerProductoid", commandType: CommandType.StoredProcedure).ToList();
                

            }

        }
    }
}
