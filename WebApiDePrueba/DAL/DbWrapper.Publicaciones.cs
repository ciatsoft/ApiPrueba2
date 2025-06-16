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
        public List<ObjPublicaciones> GetAllPublicaciones(out OperationResult result)
        {
            result = new OperationResult()
            {
                Success = true
            };
            IEnumerable<ObjPublicaciones> response = new List<ObjPublicaciones>();
            try
            {
                response = GetObjects<ObjPublicaciones>("GetAllPublicaciones", System.Data.CommandType.StoredProcedure,
                    new Func<System.Data.IDataReader, ObjPublicaciones>(r =>
                    {
                        var publicaciones = FillEntity<ObjPublicaciones>(r);

                        return publicaciones;
                    }));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return response.ToList();
        }
        public ObjPublicaciones GetPublicacionesForId(int id,out OperationResult result)
        {
            result = new OperationResult()
            {
                Success = true
            };
            ObjPublicaciones response = new ObjPublicaciones();
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
                response = GetObject<ObjPublicaciones>("GetPublicacionesForId", System.Data.CommandType.StoredProcedure, parametros,
                    new Func<System.Data.IDataReader, ObjPublicaciones>(r =>
                    {
                        var publicaciones = FillEntity<ObjPublicaciones>(r);

                        return publicaciones;
                    }));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return response;
        }
        public ObjPublicaciones SaveOrUpdatePublicaciones(ObjPublicaciones obj, out OperationResult result)
        {
            result = new OperationResult()
            {
                Success = true
            };
            ObjPublicaciones response = new ObjPublicaciones();
            var parametros = GenerateSQLParameters(obj);
            try
            {
                response = GetObject<ObjPublicaciones>("SaveOrUpdatePublicaciones", System.Data.CommandType.StoredProcedure, parametros,
                    new Func<System.Data.IDataReader, ObjPublicaciones>(r =>
                    {
                        var publicaciones = FillEntity<ObjPublicaciones>(r);

                        return publicaciones;
                    }));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return response;
        }
        public ObjPublicaciones GetAllPublicacionesForId(int Id, out OperationResult result)
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
            ObjPublicaciones response = new ObjPublicaciones();
            try
            {
                response = GetObject<ObjPublicaciones>("GetAllPublicacionesForId", CommandType.StoredProcedure, parametros,
                   new Func<System.Data.IDataReader, ObjPublicaciones>(r =>
                   {
                       var publicaciones = FillEntity<ObjPublicaciones>(r);

                       return publicaciones;
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
