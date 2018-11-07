using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyEat.UI.Code
{
    public static class LocalHelpers
    {
        public static void ShowMessage(string message, MessageType type)
        {
            if (!string.IsNullOrEmpty(message))
            {
                LocalMessage mes = new LocalMessage { Message = message, Type = type };
                HttpContext.Current.Session["Message"] = mes;
            }
        }
        public static void ShowDataInsertSuccessMessage()
        {
            LocalMessage mes = new LocalMessage { Message = "Dato Insertado con Exito", Type = MessageType.Information };
            HttpContext.Current.Session["Message"] = mes;
        }
        public static void ShowDataDeleteSuccessMessage()
        {

            LocalMessage mes = new LocalMessage { Message = "Dato Eliminado con Exito", Type = MessageType.Information };
            HttpContext.Current.Session["Message"] = mes;
        }
        public static void ShowDataUpdateSuccessMessage()
        {
            LocalMessage mes = new LocalMessage { Message = "Dato Actualizado con Exito", Type = MessageType.Information };
            HttpContext.Current.Session["Message"] = mes;
        }

        public static SelectList GetSelectListForDDL(string name,
                            string selectedValue,
                            string value,
                            string displayValue,
                            bool filtering = false
                            )
        {
            SelectList List = new SelectList(new List<string>());
            switch (name)
            {

                case "SystemUserId":
                //Core.SystemUserCore CoreSystemUser = new Core.SystemUserCore();
                //var listSystemUser = CoreSystemUser.GetAllSystemUser();
                //listSystemUser.Insert(0, new SystemUserModel { SystemUserId = 0, SystemUser = "--Seleccione--" });
                //List = new SelectList(listSystemUser, value, displayValue, selectedValue);
                //break;

                default:
                    break;
            }
            return List;

        }

    }


}