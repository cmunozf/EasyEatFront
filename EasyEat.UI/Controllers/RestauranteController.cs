
using EasyEat.Models;
using EasyEat.UI.Code;

using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyEat.UI.Controllers
{
    public class RestauranteController : MainController
    {
        Core.RestauranteCore core = new Core.RestauranteCore();
        
        public ActionResult Index()
        {
		    LoadData();
            return View();
        }


	    private void LoadData()
        {
            List<RestauranteModel> list = core.GetAllRestaurante();
            ViewData["DataRestaurante"] = list;
        }
        public ActionResult Create()
        {
            var model = new RestauranteModel();
			ViewData["Action"] = "Crear Restaurante";
			ViewData["Btn"] = "Crear";
            return PartialView("Edit",model);
        }
		[OutputCache(Duration=0)]
        public ActionResult Edit(int id)
        {
            var model = core.GetRestaurante(id);
			ViewData["Action"] = "Editar Restaurante";
            ViewData["Btn"] = "Editar";
            return PartialView(model);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(RestauranteModel model)
        {
            try
            {
                if (model.RestauranteId > 0)
                {
                    core.ModifyRestaurante(model);
                    LocalHelpers.ShowDataUpdateSuccessMessage(); 
                }
                else
                {
                    core.AddRestaurante(model);
                    LocalHelpers.ShowDataInsertSuccessMessage(); 
                }
            }
            catch (Exception ex)
            {
                LocalHelpers.ShowMessage(ex.Message,MessageType.Error); 
            }
            
            return RedirectToAction("Index");
        }

	    public JsonResult Delete(String tipoDocumento, String numeroDocumento)
        {
            try
            {
                core.DeleteRestaurante(tipoDocumento, numeroDocumento);
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

