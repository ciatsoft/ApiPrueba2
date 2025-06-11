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
        public List<ObjLaptop> GetAllLaptop(out OperationResult result)
        {
            result = new OperationResult()
            {
                Success = true
            };
            IEnumerable<ObjLaptop> response = new List<ObjLaptop>();
            try
            {
                response = GetObjects<ObjLaptop>("GetAllLaptop", System.Data.CommandType.StoredProcedure,
                new Func<System.Data.IDataReader, ObjLaptop>(r =>
                {
                    var laptop = FillEntity<ObjLaptop>(r);
                    return laptop;
                }));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return response.ToList();
        }

        public ObjLaptop GetLaptopByBrand(string brand, out OperationResult result)
        {
            result = new OperationResult()
            {
                Success = true
            };
            ObjLaptop response = null;

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = brand,
                    ParameterName = "@Brand"
                }
            };

            try
            {
                response = GetObject<ObjLaptop>("GetLaptopByBrand", CommandType.StoredProcedure, parametros,
                    new Func<System.Data.IDataReader, ObjLaptop>(r =>
                    {
                        var laptop = FillEntity<ObjLaptop>(r);
                        return laptop;
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