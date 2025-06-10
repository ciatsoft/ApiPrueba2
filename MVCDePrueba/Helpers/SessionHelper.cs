using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDePrueba.Models.Autenticacion;

namespace MVCDePrueba.Helpers
{
    public static class SessionHelper
    {
        public static void CreateSession(string id)
        {

        }
        public static TokenCookie GetSession()
        {
            return new TokenCookie();
        }
    }
}