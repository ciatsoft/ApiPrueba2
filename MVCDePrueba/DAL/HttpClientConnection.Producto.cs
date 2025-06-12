using MVCDePrueba.Models;
using MVCDePrueba.Models.Autenticacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MVCDePrueba.DAL
{
    public partial class HttpClientConnection
    {
        public async Task<ModelResponse> GetAllProductos(string token)
        {
            var result = await RequestAsync($"api/Producto/GetAllProductos", HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }), token);

            var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(result);

            return modelResponse;
        }

        public async Task<ModelResponse> AutenticacionLaptop(string token, ObjUsuario credentials)
        {
            var requestBodyJson = JsonConvert.SerializeObject(credentials);

            var result = await RequestAsync<string>($"api/Producto/GetProductosForId", HttpMethod.Post, requestBodyJson,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }), token, "application/json");

            var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(result);

            return modelResponse;
        }
    }


}