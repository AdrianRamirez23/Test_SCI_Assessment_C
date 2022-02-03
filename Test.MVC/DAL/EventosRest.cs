using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using Test.MVC.Models;

namespace Test.MVC.DAL
{
    public class EventosRest
    {
        public ResultForm Consultar(ResquestForm request) 
        {
            try
            {
                //Se inicializa protocolo seguro
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //Se serializa a json el objeto request para el evento post
                var jsonStringName = new JavaScriptSerializer();
                var jsonStringResult = jsonStringName.Serialize(request);
                //Se obtiene URL parametrizada en web config
                string url = ConfigurationManager.AppSettings["URL"];
                //Se configura el ambiente para la consulta 
                var client = new RestClient(url);
                var req = new RestRequest(Method.POST);
                req.AddHeader("content-type", "application/json");
                req.AddParameter("application/json", jsonStringResult, ParameterType.RequestBody);
                //Se ejecuta el evento post de la API
                IRestResponse response = client.Execute(req);
                //Se deseerializa el json de respuesta convirtiendo el resultado en un objeto result
                var datos = JsonConvert.DeserializeObject<ResultForm>(response.Content);
                //se retorna los datos
                return datos;
            }
            catch (Exception ex)
            {

                throw(ex);
            }
        
        }
    }
}