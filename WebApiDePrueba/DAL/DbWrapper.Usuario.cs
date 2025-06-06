using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiDePrueba.DAL;
using WebApiDePrueba.Models;

namespace WebApiDePrueba.DAL
{
	public partial class DbWrapper
	{
		public List<ObjUsuario> GetAllUsuario(out OperationResult result)
		{
            result = new OperationResult()
            { 
                Success = true
            };
            IEnumerable<ObjUsuario> response = new List<ObjUsuario>();
            try
            {
                response = GetObjects("GetAllUsuario", System.Data.CommandType.StoredProcedure,
                   new Func<System.Data.IDataReader, ObjUsuario>(r =>
                   {
                       var usuario = FillEntity<ObjUsuario>(r);

                       return usuario;
                   }));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "El sistema no esta disponible.";//ex.Message;
            }
			return response.ToList();
		}
        public ObjUsuario GetUserByUserNameAndPass(string userNama, string pass)
        {
            var parametros = new List<SqlParameter>()
            { 
                new SqlParameter()
                { 
                    Value = userNama,
                    ParameterName = "@UserName"
                },
                new SqlParameter()
                {
                    Value = pass,
                    ParameterName = "@Pass"
                }
            };
            var response = GetObject<ObjUsuario>("GetUserByUserNameAndPass", CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjUsuario>(r =>
                {
                    var usuario = FillEntity<ObjUsuario>(r);

                    return usuario;
                }));

            return response;
        }
    }
}