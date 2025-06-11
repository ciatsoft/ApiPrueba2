using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDePrueba.Models
{
    public class ModelResponse
    {
<<<<<<< HEAD

        public ModelResponse()
        {
            Result = new OperationResult();
        }

=======
>>>>>>> parent of 78dfde0 (Merge pull request #7 from ciatsoft/feature/RamaTrabajoIvan)
        public object Response { get; set; }
        public OperationResult Result { get; set; }
    }
    public class OperationResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}