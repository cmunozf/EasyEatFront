
using EasyEat.Models;
using EasyEat.UI.Code;

using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyEat.UI.Controllers
{
    public class PedidoController : MainController
    {
        
        Core.PedidoCore core = new Core.PedidoCore();
        
        public ActionResult Index()
        {
		    LoadData();
            return View();
        }


	    private void LoadData()
        {
            List<PedidoModel> list = core.GetAllPedido();
            ViewData["DataPedido"] = list;
        }
        
        public ActionResult Create()
        {
            var model = new PedidoModel();
			ViewData["Action"] = "Crear Pedido";
			ViewData["Btn"] = "Crear";
            return PartialView("Edit",model);
        }
		[OutputCache(Duration=0)]
        
        public ActionResult Edit(int id)
        {
            var model = core.GetPedido(id);
			ViewData["Action"] = "Editar Pedido";
            ViewData["Btn"] = "Editar";
            return PartialView(model);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(PedidoModel model)
        {
            try
            {
                if (model.PedidoId > 0)
                {
                    core.ModifyPedido(model);
                    LocalHelpers.ShowDataUpdateSuccessMessage(); 
                }
                else
                {
                    core.AddPedido(model);
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
                core.DeletePedido(id);
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

