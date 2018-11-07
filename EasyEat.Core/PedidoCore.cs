using EasyEat.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace EasyEat.Core
{
    public partial class PedidoCore
    {
        public PedidoModel GetPedido(Int32 PedidoId)
        {
            //DataTable table = DAL.PedidoDataAccess.GetPedido(PedidoId);
            //List<PedidoModel> list = Helpers.Utility.DataToList<PedidoModel>(typeof(PedidoModel), table);
            List<PedidoModel> list = new List<PedidoModel>();
            return list.FirstOrDefault();
        }

        public List<Models.PedidoModel> GetAllPedido()
        {
            //DataTable table = DAL.PedidoDataAccess.GetPedido();
            //List<PedidoModel> list = Helpers.Utility.DataToList<PedidoModel>(typeof(PedidoModel), table);
            List<PedidoModel> list = new List<PedidoModel>();
            return list;
        }

        public void AddPedido(PedidoModel model)
        {
            //DAL.PedidoDataAccess.AddPedido(model, user);
        }

        public void ModifyPedido(PedidoModel model)
        {
            //DAL.PedidoDataAccess.ModifyPedido(model, user);
        }

        public void DeletePedido(Int32 PedidoId)
        {
            //DAL.PedidoDataAccess.DeletePedido(PedidoId, user);
        }
    }
}
