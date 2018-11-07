using EasyEat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyEat.UI.Controllers
{
    public class HacerPedidoController : Controller
    {
        // GET: HacerPedido
        public ActionResult Index()
        {

            Core.RestauranteCore core = new Core.RestauranteCore();
            List<RestauranteModel> list = core.GetAllRestaurante();

            Core.ProductoCore core1 = new Core.ProductoCore();
            List<ProductoModel> listProductos = core1.GetAllProducto();

            ViewData["RestaurantData"] = list;
            ViewData["ProductosData"] = listProductos;
            return View();
        }
    }
}