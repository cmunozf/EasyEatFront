
using EasyEat.Models;
using EasyEat.UI.Code;

using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyEat.UI.Controllers
{
    public class ProductoController : MainController
    {
        
        Core.ProductoCore core = new Core.ProductoCore();

        
        public ActionResult Index()
        {
		    LoadData();
            return View();
        }


	    private void LoadData()
        {
            List<ProductoModel> list = core.GetAllProducto();
            ViewData["DataProducto"] = list;
        }
        
        public ActionResult Create()
        {
            var model = new ProductoModel();
			ViewData["Action"] = "Crear Producto";
			ViewData["Btn"] = "Crear";
            return PartialView("Edit",model);
        }
		[OutputCache(Duration=0)]
        
        public ActionResult Edit(int id)
        {
            var model = core.GetProducto(id);
			ViewData["Action"] = "Editar Producto";
            ViewData["Btn"] = "Editar";
            return PartialView(model);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(ProductoModel model)
        {
            try
            {
                if (model.ProductoId > 0)
                {
                    //core.ModifyProducto(model);
                    LocalHelpers.ShowDataUpdateSuccessMessage(); 
                }
                else
                {
                    core.AddProducto(model);
                    LocalHelpers.ShowDataInsertSuccessMessage(); 
                }
            }
            catch (Exception ex)
            {
                LocalHelpers.ShowMessage(ex.Message,MessageType.Error); 
            }
            
            return RedirectToAction("Index");
        }
        

	    public JsonResult Delete(int id)
        {
            try
            {
                core.DeleteProducto(id);
                LocalHelpers.ShowDataDeleteSuccessMessage();
				return Json(new { result = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LocalHelpers.ShowMessage("Ocurrio el siguiente error: " + ex, MessageType.Error);
                return Json(new { result = string.Format("Err:{0}", ex.Message) }, JsonRequestBehavior.AllowGet);
            }
           
        }

    }
}

