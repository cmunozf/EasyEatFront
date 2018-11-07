using EasyEat.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
            var baseAddress = "http://localhost:8090/pago/agregarpago";

            var json = JsonConvert.SerializeObject(model);

            var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";

            string parsedContent = json;
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
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
