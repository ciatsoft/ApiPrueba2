using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiDePrueba.DAL;
using WebApiDePrueba.Models;

namespace WebApiDePrueba.Controllers
{
        // GET: Laptop
        [Authorize]
        [RoutePrefix("api/Laptop")]
        public class LaptopController : ApiController
        {
            private DbWrapper wrapper;
            public LaptopController()
            {
                wrapper = new DbWrapper();
            }

            [HttpGet]
            [Route("GetAllLaptop")]
            public ModelResponse GetAllLaptop()
            {
                var response = new ModelResponse()
                {
                    Response = wrapper.GetAllLaptop(out OperationResult result),
                    Result = result
                };
                return response;
            }

            [HttpPost]
            [Route("AutenticacionLaptop")]
            public ModelResponse AutenticacionLaptop(ObjLaptop request)
            {
                var response = new ModelResponse()
                {
                    Response = wrapper.GetLaptopByBrand(request.Brand, out OperationResult result),
                    Result = result
                };
                return response;
            }

        }
    }