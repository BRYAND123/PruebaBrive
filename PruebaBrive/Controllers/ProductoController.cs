using Microsoft.AspNetCore.Mvc;
using PruebaBrive.Data;
using PruebaBrive.Models;

namespace PruebaBrive.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProducto _iproducto;

        public ProductoController(IProducto iproducto)
        {
            _iproducto = iproducto;
        }
        public IActionResult Index()
        {
            var producto = _iproducto.ObtenerProductos();
            return View(producto);
        }

        public IActionResult Detalle(int id)
        {
            var producto = _iproducto.ObtenerProductoid(id);
            return View(producto);
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            _iproducto.InsertarProducto(producto);
            return RedirectToAction ("Index");
        }

        public IActionResult Editar(int id)
        {
            var producto = _iproducto.ObtenerProductoid(id);
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            _iproducto.ActulizarProducto(producto);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var producto = _iproducto.ObtenerProductoid(id);
            if (producto == null)
             return NotFound();
            
            return View();
        }
        [HttpPost]
        public IActionResult EliminarConfirmado(int id)
        {
            _iproducto.EliminarProducto(id);
            return RedirectToAction("Index");
        }

    }

}
