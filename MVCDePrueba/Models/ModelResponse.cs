using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDePrueba.Models
{
    public class ModelResponse
    {
        public ModelResponse()
        {
            Result = new OperationResult();
        }
        public object Response { get; set; }
        public OperationResult Result { get; set; }
    }
    public class OperationResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}