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
    public partial class ProductoCore
    {
        public ProductoModel GetProducto(Int32 ProductoId)
        {
            List<ProductoModel> list = new List<ProductoModel>();
            return list.FirstOrDefault();
        }
        public List<Models.ProductoModel> GetAllProducto()
        {

            var json = new WebClient().DownloadString("http://localhost:8090/producto/listarproducto/");
            List<ProductoModel> list = JsonConvert.DeserializeObject<List<ProductoModel>>(json);
            return list;
        }
        public void AddProducto(ProductoModel model)
        {
            var baseAddress = "http://localhost:8090/producto/agregarproducto";

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

        public void DeleteProducto(Int32 ProductoId)
        {
            //DAL.ProductoDataAccess.DeleteProducto(ProductoId,user);
        }
    }
}
