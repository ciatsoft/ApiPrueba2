using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDePrueba.DAL;
using WebApiDePrueba.Models;

namespace WebApiDePrueba.Controllers
{
    [Authorize]
    [RoutePrefix("api/Publicaciones")]

    public class PublicacionesController : ApiController
    {
        private DbWrapper wrapper;
        public PublicacionesController()
        {
            wrapper = new DbWrapper();
        }


        [HttpGet]
        [Route("List")]
        public ModelResponse GetAllPublicaciones()
        {
            var response = new ModelResponse()
            {
                Response = wrapper.GetAllPublicaciones(out OperationResult result),
                Result = result
            };
            return response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ModelResponse GetPublicacionesForId(int id)
        {
            var response = new ModelResponse()
            {
                Response = wrapper.GetPublicacionesForId(id, out OperationResult result),
                Result = result
            };
            return response;
        }
        [HttpPost]
        [Route("")]
        public ModelResponse SaveOrUpdatePublicaciones(ObjPublicaciones obj)
        {
            var response = new ModelResponse()
            {
                Response = wrapper.SaveOrUpdatePublicaciones(obj, out OperationResult result),
                Result = result
            };
            return response;
        }
        [HttpPost]
        [Route("Autenticacion")]
        public ModelResponse Autenticacion(ObjUsuario request)
        {
            var response = new ModelResponse()
            {
                Response = wrapper.GetAllPublicacionesForId(request.Id, out OperationResult result),
                Result = result

            };
            return response;
        }
    }
}
