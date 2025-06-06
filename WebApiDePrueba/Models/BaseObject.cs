using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDePrueba.Models
{
	public class BaseObject
	{
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDt { get; set; }
    }
}