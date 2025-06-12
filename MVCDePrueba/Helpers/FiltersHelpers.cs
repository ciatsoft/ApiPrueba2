using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCDePrueba.Helpers
{
	public class FiltersHelpers
	{
        public class AutenticatedAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);

                var validToken = SessionHelper.EixstSession();
                var tokenTemp = SessionHelper.GetSession();
                if (!validToken && tokenTemp == null)
                {
                    var rvd = new RouteValueDictionary();
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Autenticacion"
                    }));
                }
            }
        }
        public class NoAutenticatedAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);

                if (SessionHelper.EixstSession())
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Index"
                    }));
                }
            }
        }
    }
}