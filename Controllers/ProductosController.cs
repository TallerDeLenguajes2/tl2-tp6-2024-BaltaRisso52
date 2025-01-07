using Microsoft.AspNetCore.Mvc;

public class ProductosController : Controller
{
    public ActionResult Index(){
        return View(ProductoRepository.GetProductos());
    }

    [HttpGet]
    public ActionResult ModificarProducto(int id){
        var producto = ProductoRepository.GetProducto(id);
        return View(producto);
    }

    [HttpPost]
    public ActionResult ModificarProducto(Producto producto){
        ProductoRepository.ModificarProducto(producto);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult EliminarProducto(int id){
        var producto = ProductoRepository.GetProducto(id);
        return View(producto);
    }

    [HttpGet]
    public ActionResult EliminarProductoPorId(int id){
        ProductoRepository.EliminarProducto(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult AltaProducto(){
        return View();
    }

    [HttpPost]
    public ActionResult CrearProducto(ProductoPostDto productoPostDto){
        ProductoRepository.CrearProducto(productoPostDto);
        return RedirectToAction("Index");
    }
}