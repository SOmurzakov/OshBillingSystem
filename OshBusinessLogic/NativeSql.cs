using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Collections;

namespace OshBusinessLogic
{
    public static class NativeSql
    {

        public static SqlConnection CreateSqlConnection()
        {
            string connectionString = ConfigurationManager.AppSettings["DatabaseConnectionString"];
            return new SqlConnection(connectionString);
        }

        //

        public static DataTable Exec(string procedure)
        {
            return Exec(procedure, null);
        }

        public static DataTable Exec(string procedure, object argumentsContainer)
        {
            using (SqlConnection connection = NativeSql.CreateSqlConnection())
            {
                connection.Open();

                var res = Exec(connection, procedure, argumentsContainer);

                connection.Close();

                return res;
            }
        }

        public static DataTable Exec(SqlConnection sqlConnection, string procedure, object argumentsContainer)
        {
            DataTable table = new DataTable();

            using (SqlCommand cmd = new SqlCommand(procedure, sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                if (argumentsContainer != null)
                {
                    if (argumentsContainer is SqlParameter)
                    {
                        cmd.Parameters.Add(argumentsContainer as SqlParameter);
                    }
                    else
                    {
                        List<SqlParameter> parameters = GetParameters(argumentsContainer);
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }
            }

            return table;
        }

        //

        private static List<SqlParameter> GetParameters(object argumentsContainer)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (argumentsContainer != null)
            {
                Type containerType = argumentsContainer.GetType();
                var properties = containerType.GetProperties();

                foreach (var property in properties)
                {
                    object objectValue = property.GetValue(argumentsContainer, null);

                    SqlParameter param =
                        objectValue != null && objectValue.GetType().IsArray
                        ? GetDataTableParameter(objectValue as IEnumerable, property.Name)
                        : new SqlParameter("@" + property.Name, objectValue == null ? DBNull.Value : objectValue);

                    parameters.Add(param);
                }
            }

            return parameters;
        }

        public static SqlParameter GetDataTableParameter(IEnumerable list, string parameterName)
        {
            if (!parameterName.StartsWith("@"))
            {
                parameterName = "@" + parameterName;
            }

            DataTable table = new DataTable(parameterName);

            Type objectType = list.GetType().GetElementType();
            var properties = objectType.GetProperties();

            foreach (var property in properties)
            {
                try
                {
                    Type type = property.PropertyType;
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        type = type.GetGenericArguments()[0];
                    }

                    table.Columns.Add(property.Name, type);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("{0}.{1}: {2}", objectType.Name, property.Name, ex.Message), ex);
                }
            }

            foreach (object item in list)
            {
                object[] values = GrabPropertiesForItem(item);
                table.Rows.Add(values);
            }

            SqlParameter parameter = new SqlParameter(parameterName, SqlDbType.Structured);
            parameter.Value = table;

            return parameter;
        }

        private static object[] GrabPropertiesForItem(object item)
        {
            var objectType = item.GetType();
            var properties = objectType.GetProperties();
            object[] values = new object[properties.Length];

            for (int i = 0; i < properties.Length; i++)
            {
                try
                {
                    values[i] = properties[i].GetValue(item, null);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("{0}.{1}: {2}", objectType.Name, properties[i].Name, ex.Message), ex);
                }
            }

            return values;
        }

        private static PropertyInfo[] GetColumnMappings(Type type, DataTable table)
        {
            PropertyInfo[] columnMappings = new PropertyInfo[table.Columns.Count];
            var fields = type.GetProperties();

            for (int i=0; i<table.Columns.Count; i++)
            {
                string columnName = table.Columns[i].ColumnName;
                var field = fields.FirstOrDefault(f => f.Name == columnName);

                if (field == null)
                {
                    throw new Exception(string.Format("Data type {0} does not contain field {1}", type.FullName, columnName));
                }

                columnMappings[i] = field;
            }

            return columnMappings;
        }

        //

        public static DataTable[] ExecMultiple(string procedure)
        {
            return ExecMultiple(procedure, null);
        }

        public static DataTable[] ExecMultiple(string procedure, object argumentsContainer)
        {
            using (SqlConnection connection = NativeSql.CreateSqlConnection())
            {
                connection.Open();

                var res = ExecMultiple(connection, procedure, argumentsContainer);

                connection.Close();

                return res;
            }
        }

        public static DataTable[] ExecMultiple(SqlConnection sqlConnection, string procedure, object argumentsContainer)
        {
            List<DataTable> tables = new List<DataTable>();

            using (SqlCommand cmd = new SqlCommand(procedure, sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                if (argumentsContainer != null)
                {
                    if (argumentsContainer is SqlParameter)
                    {
                        cmd.Parameters.Add(argumentsContainer as SqlParameter);
                    }
                    else
                    {
                        List<SqlParameter> parameters = GetParameters(argumentsContainer);
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                }

                SqlDataReader reader = cmd.ExecuteReader();

                do
                {

                    DataTable table = new DataTable();
                    table.Load(reader);
                    tables.Add(table);

                } while (!reader.IsClosed);

                //reader.Close();
            }

            return tables.ToArray();
        }

        //

        public static T[] Rows<T>(this DataTable table) where T : new()
        {
            PropertyInfo[] columnMappings = GetColumnMappings(typeof(T), table);
            int colCount = columnMappings.Length;

            T[] results = new T[table.Rows.Count];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = new T();
                var resObject = results[i];
                var tableRow = table.Rows[i];

                for (int j = 0; j < colCount; j++)
                {
                    object value = tableRow[j];
                    try
                    {
                        columnMappings[j].SetValue(resObject, value == DBNull.Value ? null : value, null);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(string.Format("{1}.{0}: {2}", columnMappings[j].Name, typeof(T).Name, ex.Message));
                    }
                }
            }

            return results;
        }

        public static T OneRow<T>(this DataTable table) where T : new()
        {
            return table.Rows<T>().FirstOrDefault();
        }

        public static T[] Rows<T>(this DataTable[] tables) where T : new()
        {
            return tables[0].Rows<T>();
        }

        public static T OneRow<T>(this DataTable[] tables) where T : new()
        {
            return tables[0].Rows<T>().FirstOrDefault();
        }

    }
}
