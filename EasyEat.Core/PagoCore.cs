using EasyEat.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace EasyEat.Core
{
    public partial class PagoCore
    {

        public PagoModel GetPago(Int32 PagoId)
        {
            //DataTable table = DAL.PagoDataAccess.GetPago(PagoId);
            //List<PagoModel> list = Helpers.Utility.DataToList<PagoModel>(typeof(PagoModel), table);
            List<PagoModel> list = new List<PagoModel>();
            return list.FirstOrDefault();
        }

        public List<Models.PagoModel> GetAllPago()
        {
            //DataTable table = DAL.PagoDataAccess.GetPago();
            //List<PagoModel> list = Helpers.Utility.DataToList<PagoModel>(typeof(PagoModel), table);
            List<PagoModel> list = new List<PagoModel>();
            return list;
        }

        public void AddPago(PagoModel model)
        {
            //DAL.PagoDataAccess.AddPago(model,user);
        }

        public void ModifyPago(PagoModel model)
        {
            //DAL.PagoDataAccess.ModifyPago(model,user);
        }

        public void DeletePago(Int32 PagoId)
        {
            //DAL.PagoDataAccess.DeletePago(PagoId,user);
        }
    }
}
