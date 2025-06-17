using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDePrueba.Models
{
	public class ObjUsuario : BaseObject
	{
        public string UserName { get; set; }
        public string Pass { get; set; }
    }
}