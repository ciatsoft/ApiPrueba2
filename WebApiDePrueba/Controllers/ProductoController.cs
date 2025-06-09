using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDePrueba.DAL;
using WebApiDePrueba.Models;

namespace WebApiDePrueba.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Producto")]
    public class ProductoController : ApiController
    {
        private DbWrapper wrapper;
        public ProductoController()
        {
            wrapper = new DbWrapper();
            
        }

        [HttpGet]
        [Route("GetAllProductos")]
        public ModelResponse GetAllProductos()
        {
            var response = new ModelResponse()
            {
                Response = wrapper.GetAllProductos(out OperationResult result),
                Result = result
            };

            return response;

        }
        [HttpPost]
        [Route("GetProductosForId")]
        public ModelResponse GetProductosForId(ObjProducto request)
        {
            var response = new ModelResponse()
            {
                Response = wrapper.GetProductosForId(request.Id, out OperationResult result),
                Result = result
            };

            return response;
        }
    }
}
