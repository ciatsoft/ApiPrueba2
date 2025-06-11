using MVCDePrueba.Models.Autenticacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVCDePrueba.Helpers
{
	public static class SessionHelper
	{
		public static void CreateDession(TokenCookie tokenCookie)
		{
            bool persist = true;
            var cookie = FormsAuthentication.GetAuthCookie("token", persist);

            cookie.Name = FormsAuthentication.FormsCookieName;
            cookie.Expires = tokenCookie.token.ExpirationDate;

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, cookie.Expires, ticket.IsPersistent, JsonConvert.SerializeObject(tokenCookie));

            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
		public static TokenCookie GetSession()
		{
            TokenCookie u = null;

            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;

                if (ticket != null)
                {
                    u = JsonConvert.DeserializeObject<TokenCookie>(ticket.UserData);
                }
            }

            return u;
        }
	}
}