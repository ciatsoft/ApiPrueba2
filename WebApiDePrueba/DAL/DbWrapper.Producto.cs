using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Management;
using WebApiDePrueba.Models;

namespace WebApiDePrueba.DAL
{
    public partial class DbWrapper
    {
        public List<ObjProducto> GetAllProductos(out OperationResult result)
        {
            result = new  OperationResult()
            {
                Success= true
            };
            IEnumerable<ObjProducto> response = new List<ObjProducto>();

            try
            {
                response = GetObjects<ObjProducto>("GetAllProductos", System.Data.CommandType.StoredProcedure,
                    new Func<System.Data.IDataReader, ObjProducto>(r =>
                    {
                        var producto = FillEntity<ObjProducto>(r);
                        return producto;
                        }));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                throw;
            }
            return response.ToList();
        }
        public ObjProducto GetProductosForId(int Id, out OperationResult result)
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
                }
            };
            ObjProducto response = new ObjProducto();
            try
            {
                response = GetObject<ObjProducto>("GetProductosForId", CommandType.StoredProcedure, parametros,
                    new Func<System.Data.IDataReader, ObjProducto>(r =>
                    {
                        var producto = FillEntity<ObjProducto>(r);

                        return producto;
                    }));
            }
            catch
            (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                throw;
            }

            return response;
        }
    }
}