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
    public partial class FacturaCore
    {

        public FacturaModel GetFactura(Int32 FacturaId)
        {
            var baseAddress = "http://localhost:8090/factura/listarfactura";

            var json = "{\"referenciaPago\": " + FacturaId + "}";
            

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

            content = content.Replace("[]","\"\"");

            FacturaModel list = JsonConvert.DeserializeObject<FacturaModel>(content);

            return list;

        }

        public List<FacturaModel> GetAllFactura()
        {
            var json = new WebClient().DownloadString("http://localhost:8090/factura/listarfacturaTotal");
            List<FacturaModel> list = JsonConvert.DeserializeObject<List<FacturaModel>>(json);
            return list;

            //List<FacturaModel> list = new List<FacturaModel>();
            //return list;
        }

        public void AddFactura(FacturaModel model)
        {
            var baseAddress = "http://localhost:8090/factura/agregarfactura";
            model.productos = new List<ProductoModel>();
            var json = JsonConvert.SerializeObject(model);
            json = json.Replace("\"[]\"","[]");

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

        public void ModifyFactura(FacturaModel model)
        {
            //DAL.FacturaDataAccess.ModifyFactura(model,user);
        }

        public void DeleteFactura(Int32 FacturaId)
        {
            //DAL.FacturaDataAccess.DeleteFactura(FacturaId,user);
        }
    }
}
