using EasyEat.Core;
using EasyEat.Models;
using EasyEat.UI.Code;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyEat.UI.Controllers
{
    public class FacturaController : MainController
    {
        
        Core.FacturaCore core = new Core.FacturaCore();

        
        public ActionResult Index()
        {
		    LoadData();
            return View();
        }


	    private void LoadData()
        {
            List<FacturaModel> list = core.GetAllFactura();
            ViewData["DataFactura"] = list;
        }
        
        public ActionResult Create()
        {
            var model = new FacturaModel();
			ViewData["Action"] = "Crear Factura";
			ViewData["Btn"] = "Crear";
            return PartialView("Edit",model);
        }
		[OutputCache(Duration=0)]
        
        public ActionResult Edit(int id)
        {
            var model = core.GetFactura(id);
			ViewData["Action"] = "Editar Factura";
            ViewData["Btn"] = "Editar";
            return PartialView(model);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(FacturaModel model)
        {
            try
            {
                if (model.FacturaId > 0)
                {
                    core.ModifyFactura(model);
                    LocalHelpers.ShowDataUpdateSuccessMessage(); 
                }
                else
                {
                    core.AddFactura(model);
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
                core.DeleteFactura(id);
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

