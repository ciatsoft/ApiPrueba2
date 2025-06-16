using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiDePrueba.Models;

namespace WebApiDePrueba.DAL
{
    public partial class DbWrapper
    {
        public List<ObjAutomovil> GetAllAutomovil(out OperationResult result)
        {
            result = new OperationResult()
            {
                Success = true
            };
            IEnumerable<ObjAutomovil> response = new List<ObjAutomovil>();
            try
            {
                response = GetObjects<ObjAutomovil>("GetAllAutomovil", System.Data.CommandType.StoredProcedure,
                    new Func<System.Data.IDataReader, ObjAutomovil>(r =>
                    {
                        var automovil = FillEntity<ObjAutomovil>(r);

                        return automovil;
                    }));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return response.ToList();
        }
        public ObjAutomovil GetAutomovilForId(int id, out OperationResult result)
        {
            result = new OperationResult()
            {
                Success = true
            };
            ObjAutomovil response = new ObjAutomovil();
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };
            try
            {
                response = GetObject<ObjAutomovil>("GetAllAutomovilForId", System.Data.CommandType.StoredProcedure, parametros,
                    new Func<System.Data.IDataReader, ObjAutomovil>(r =>
                    {
                        var automovil = FillEntity<ObjAutomovil>(r);

                        return automovil;
                    }));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return response;
        }
        public ObjAutomovil SaveOrUpdateAutomovil(ObjAutomovil obj, out OperationResult result)
        {
            result = new OperationResult()
            {
                Success = true
            };
            ObjAutomovil response = new ObjAutomovil();
            var parametros = GenerateSQLParameters(obj);
            try
            {
                response = GetObject<ObjAutomovil>("SaveOrUpdateAutomovil", System.Data.CommandType.StoredProcedure, parametros,
                    new Func<System.Data.IDataReader, ObjAutomovil>(r =>
                    {
                        var automovil = FillEntity<ObjAutomovil>(r);

                        return automovil;
                    }));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return response;
        }
        public ObjAutomovil GetAllAutomovilForId(int Id, out OperationResult result)
        {
            result = new OperationResult()
            {
                Success = true
            };
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = Id,
                    ParameterName = "@Id"
                },
            };
            ObjAutomovil response = new ObjAutomovil();
            try
            {
                response = GetObject<ObjAutomovil>("GetAllAutomovilForId", CommandType.StoredProcedure, parametros,
                   new Func<System.Data.IDataReader, ObjAutomovil>(r =>
                   {
                       var automovil = FillEntity<ObjAutomovil>(r);

                       return automovil;
                   }));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }

            return response;
        }

    }
}