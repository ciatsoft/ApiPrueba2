using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiDePrueba.DAL;
using WebApiDePrueba.Models;

namespace WebApiDePrueba.Controllers
{
    //GET: Automovil
    [Authorize]
    [RoutePrefix("api/Automovil")]

    public class AutomovilController : ApiController
    {
        private DbWrapper wrapper;
        public AutomovilController()
        {
            wrapper = new DbWrapper();
        }


        [HttpGet]
        [Route("List")]
        public ModelResponse GetAllAutomovil()
        {
            var response = new ModelResponse()
            {
                Response = wrapper.GetAllAutomovil(out OperationResult result),
                Result = result
            };
            return response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ModelResponse GetAllAutomovilForId(int id)
        {
            var response = new ModelResponse()
            {
                Response = wrapper.GetAllAutomovilForId(id, out OperationResult result),
                Result = result
            };
            return response;
        }
        [HttpPost]
        [Route("")]
        public ModelResponse SaveOrUpdateAutomovil(ObjAutomovil obj)
        {
            var response = new ModelResponse()
            {
                Response = wrapper.SaveOrUpdateAutomovil(obj, out OperationResult result),
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
                Response = wrapper.GetAllAutomovilForId(request.Id, out OperationResult result),
                Result = result

            };
            return response;
        }
    }
}