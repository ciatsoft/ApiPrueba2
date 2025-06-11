using MVCDePrueba.DAL;
using MVCDePrueba.DAL;
using MVCDePrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDePrueba.Controllers
{
    public class BaseController : Controller
    {
        public HttpClientConnection http { get; set; }
        public ModelResponse mr { get; set; }
        public BaseController()
        {
            http = new HttpClientConnection();
            mr = new ModelResponse();
        }
    }
}