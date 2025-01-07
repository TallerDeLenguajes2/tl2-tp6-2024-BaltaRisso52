using Microsoft.AspNetCore.Mvc;

public class PresupuestosController : Controller
{
    public ActionResult Index()
    {
        return View(PresupuestoRepository.GetPresupuestos());
    }

    [HttpGet]
    public ActionResult AltaPresupuesto()
    {
        return View();
    }

    [HttpPost]
    public ActionResult CrearPresupuesto(Presupuesto presupuesto)
    {
        PresupuestoRepository.CrearPresupuesto(presupuesto);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult ModificarPresupuesto(int id)
    {
        var productos = ProductoRepository.GetProductos();
        var presupuesto = PresupuestoRepository.GetPresupuesto(id);

        var viewModel = new AgregarProductoViewModel
        {
            Presupuesto = presupuesto,
            Productos = productos
        };

        return View(viewModel);
    }

    [HttpGet]
    public ActionResult EliminarProductoDePresupuesto(int id1, int id2)
    {
        PresupuestoRepository.EliminarProductoPorId(id2, id1);
        return RedirectToAction("ModificarPresupuesto", new { id = id2 });
    }

    [HttpPost]
    public ActionResult ModificarPresupuestoOK(int idPresupuesto, int idProducto, int cantidad)
    {
        if (cantidad > 0)
        {
            PresupuestoRepository.ModificarCantidadProducto(idPresupuesto, idProducto, cantidad);
        }
        return RedirectToAction("ModificarPresupuesto", new { id = idPresupuesto });
    }

    [HttpPost]
    public ActionResult AgregarProducto(int idPresupuesto, int idProducto, int cantidad)
    {
        if (PresupuestoRepository.AgregarProducto(idPresupuesto, idProducto, cantidad))
        {
            return RedirectToAction("ModificarPresupuesto", new { id = idPresupuesto });
        }


        return RedirectToAction("ModificarPresupuesto", new { id = idPresupuesto });
    }

    [HttpGet]
    public ActionResult EliminarPresupuesto(int id){
        var producto = PresupuestoRepository.GetPresupuesto(id);
        return View(producto);
    }

    [HttpGet]
    public ActionResult EliminarPresupuestoPorId(int id){
        PresupuestoRepository.EliminarPresupuestoPorId(id);
        return RedirectToAction("Index");
    }
}