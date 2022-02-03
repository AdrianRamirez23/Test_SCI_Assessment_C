using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Test.MVC.DAL;
using Test.MVC.Models;

namespace Test.MVC.Controllers
{
    public class SCIController : Controller
    {
        // GET: SCI
        public ActionResult Index()
        {
            //Se inicializa el controlador con el objeto que recibirá desde el formulario
            ResquestForm resquest = new ResquestForm();
            return View(resquest);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(ResquestForm request )
        {
            //Se valida si el objeto enviado es válido
            if (ModelState.IsValid)
            {
                //Se realizar la consulta al método de la clase EventosRest
                var result = new EventosRest().Consultar(request);
                //Se retorna los datos a la vista de resultados enviando los valores obtenidos
                return RedirectToAction("Index","SCIResult", new RouteValueDictionary(result) );
            }
            else 
            {
                return View();
            }
            
        }
    }
}