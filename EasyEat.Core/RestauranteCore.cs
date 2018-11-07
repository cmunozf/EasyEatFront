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
    public partial class RestauranteCore
    {

        public RestauranteModel GetRestaurante(Int32 RestauranteId)
        {
            //DataTable table = DAL.RestauranteDataAccess.GetRestaurante(RestauranteId);
            //List<RestauranteModel> list = Helpers.Utility.DataToList<RestauranteModel>(typeof(RestauranteModel), table);
            List<RestauranteModel> list = new List<RestauranteModel>();
            return list.FirstOrDefault();
        }

        public List<Models.RestauranteModel> GetAllRestaurante()
        {
            var json = new WebClient().DownloadString("http://localhost:8090/restaurante/listarrestaurante");
            List<RestauranteModel> list = JsonConvert.DeserializeObject<List<RestauranteModel>>(json);
            return list;
        }

        public void AddRestaurante(RestauranteModel model)
        {
            var baseAddress = "http://localhost:8090/restaurante/registrarrestaurante";
            
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

        public void ModifyRestaurante(RestauranteModel model)
        {
            //DAL.RestauranteDataAccess.ModifyRestaurante(model,user);
        }

        public void DeleteRestaurante(String tipoDocumento,String numeroDocumento)
        {
            var baseAddress = "http://localhost:8090/restaurante/eliminarrestaurante";

            var json = "{\"tipoDocumento\": " + tipoDocumento + ",\"numeroDocumento\": " + numeroDocumento+"}";
            
            var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "DELETE";

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
    }
}
