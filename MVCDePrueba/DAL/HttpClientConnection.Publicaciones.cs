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
        public async Task<ModelResponse> GetAllPublicaciones()
        {
            var result = await RequestAsync($"api/Publicaciones/List", HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }), tokenCookie.token.access_token);

            var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(result);

            return modelResponse;
        }
        public async Task<ModelResponse> GetPublicacionesForId(int id)
        {
            var result = await RequestAsync($"api/Publicaciones/{id}", HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }), tokenCookie.token.access_token);

            var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(result);

            return modelResponse;
        }
        public async Task<ModelResponse> SaveOrUpdatePublicaciones(ObjPublicaciones obj)
        {
            MappingColumSecurity(obj);

            var result = await RequestAsync<object>($"api/Publicaciones", HttpMethod.Post, obj,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }), tokenCookie.token.access_token);

            var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(result.ToString());

            return modelResponse;
        }
    }
}