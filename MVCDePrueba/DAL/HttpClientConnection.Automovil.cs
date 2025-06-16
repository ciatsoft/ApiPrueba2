using MVCDePrueba.Models;
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
        public async Task<ModelResponse> GetAllAutomovil()
        {
            var result = await RequestAsync($"api/Automovil/List", HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }), tokenCookie.token.access_token);

            var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(result);

            return modelResponse;
        }
        public async Task<ModelResponse> GetAutomovilForId(int id)
        {
            var result = await RequestAsync($"api/Automovil/{id}", HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }), tokenCookie.token.access_token);

            var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(result);

            return modelResponse;
        }
        public async Task<ModelResponse> SaveOrUpdateAutomovil(ObjAutomovil obj)
        {
            MappingColumSecurity(obj);

            var result = await RequestAsync<object>($"api/Automovil", HttpMethod.Post, obj,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }), tokenCookie.token.access_token);

            var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(result.ToString());

            return modelResponse;
        }
    }
}