using MVCDePrueba.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDePrueba.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public HttpClientConnection http { get; set; }

        public BaseController()
        {
            http = new HttpClientConnection();
        }
       
    }
}