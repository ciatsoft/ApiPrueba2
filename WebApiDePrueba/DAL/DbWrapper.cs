using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApiDePrueba.DAL
{
	public partial class DbWrapper : BaseDbWrapper
	{
        protected override string SQLConnectionString { get; }
        protected override TimeSpan SQLCommandTimeOut { get; }

        public DbWrapper()
        {
            SQLConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["cCon"].ToString();
            SQLCommandTimeOut = TimeSpan.FromSeconds(15);
        }

        public T MappingProperties<T>(object item)
        {
            if (item != DBNull.Value)
                return (T)item;
            else
                return default(T);
        }

        private T FillEntity<T>(IDataReader reader) where T : class, new()
        {
            T e = new T();
            for (int j = 0; j < reader.FieldCount; j++)
            {
                foreach (var item in e.GetType().GetProperties())
                {
                    if (reader.GetName(j).ToUpper().Equals(item.Name.ToUpper()))
                    {
                        // Si el valor de la base de datos es DBNull, asigna null
                        if (reader[j] is DBNull)
                        {
                            item.SetValue(e, null);
                        }
                        else
                        {
                            // Obtiene el valor del lector
                            object dbValue = reader[j];
                            Type propertyType = item.PropertyType;

                            // Manejo de tipos convertibles, incluyendo float/double
                            // También considera tipos que aceptan valores nulos (Nullable<T>)
                            Type underlyingType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

                            if (!underlyingType.IsEnum)
                            {
                                try
                                {
                                    // Intenta convertir el valor de la base de datos al tipo de la propiedad
                                    object convertedValue = Convert.ChangeType(dbValue, underlyingType);
                                    item.SetValue(e, convertedValue);
                                }
                                catch (InvalidCastException ex)
                                {
                                    // Aquí puedes manejar el error de forma más específica si lo necesitas
                                    // Por ejemplo, loguear el error o lanzar una excepción personalizada.
                                    // Por ahora, simplemente relanzamos la excepción para que sea visible.
                                    Console.WriteLine($"Error al convertir el campo '{reader.GetName(j)}' (DB Type: {dbValue.GetType().Name}) a la propiedad '{item.Name}' (Property Type: {propertyType.Name}): {ex.Message}");
                                    throw; // Re-lanza la excepción para que no sea ignorada silenciosamente
                                }
                                catch (Exception ex)
                                {
                                    // Captura otras posibles excepciones durante la conversión
                                    Console.WriteLine($"Error general al asignar el campo '{reader.GetName(j)}' a la propiedad '{item.Name}': {ex.Message}");
                                    throw;
                                }
                            }
                            else // Es un tipo Enum
                            {
                                var valor = dbValue.ToString();
                                // Tu lógica para manejar enums con números como string "ItemX"
                                if (char.IsDigit(valor.First()) && dbValue.GetType() == typeof(string))
                                    valor = string.Concat("Item", valor);

                                item.SetValue(e, Enum.Parse(underlyingType, valor));
                            }
                        }
                        // Una vez que el campo se ha asignado, no es necesario seguir buscando propiedades para este campo
                        break; // Rompe el bucle interno (foreach var item in e.GetType().GetProperties())
                    }
                }
            }
            return e;
        }

        public List<SqlParameter> GenerateSQLParameters<T>(T o)
        {
            var listParameters = new List<SqlParameter>();
            var parametersName = o.GetType().GetProperties();

            foreach (var p in parametersName)
            {
                if (p.GetValue(o)?.GetType().GetProperty("Id") == null)
                    listParameters.Add(new SqlParameter($"@{p.Name}", p.GetValue(o))
                    {
                        IsNullable = true
                    });
                else
                    listParameters.Add(new SqlParameter($"@{p.Name}", p.GetValue(o).GetType().GetProperty("Id").GetValue(p.GetValue(o)))
                    {
                        IsNullable = true
                    });
            }

            return listParameters;
        }
    }
}