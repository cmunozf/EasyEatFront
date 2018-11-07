
using EasyEat.Core;
using EasyEat.Models;
using EasyEat.UI.Code;

using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyEat.UI.Controllers
{
    public class PagoController : MainController
    {

        PagoCore core = new PagoCore();

        public ActionResult Index()
        {
		    LoadData();
            return View();
        }


	    private void LoadData()
        {
            List<PagoModel> list = core.GetAllPago();
            ViewData["DataPago"] = list;
        }

        public ActionResult Create()
        {
            var model = new PagoModel();
			ViewData["Action"] = "Crear Pago";
			ViewData["Btn"] = "Crear";
            return PartialView("Edit",model);
        }
		[OutputCache(Duration=0)]
        
        public ActionResult Edit(int id)
        {
            var model = core.GetPago(id);
			ViewData["Action"] = "Editar Pago";
            ViewData["Btn"] = "Editar";
            return PartialView(model);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(PagoModel model)
        {
            try
            {
                if (model.PagoId > 0)
                {
                    core.ModifyPago(model);
                    LocalHelpers.ShowDataUpdateSuccessMessage(); 
                }
                else
                {
                    core.AddPago(model);
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
                core.DeletePago(id);
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

