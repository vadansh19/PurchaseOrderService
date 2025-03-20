using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonOperation
{
    /// <summary>
    /// This class contains methods to convert collections between DataTable and other formats like ArrayList or business objects.
    /// </summary>
    public class CollectionHelper
    {
        private CollectionHelper() { }

        /// <summary>
        /// Converts a DataTable to an ArrayList.
        /// </summary>
        /// <param name="dtTable">The DataTable to convert.</param>
        /// <returns>An ArrayList representation of the DataTable.</returns>
        public static ArrayList ConvertDataTableToArrayList(DataTable dtTable)
        {
            ArrayList resultArrayList = null;

            if (dtTable != null)
            {
                resultArrayList = new ArrayList();
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    ArrayList currRow = new ArrayList();
                    for (int j = 0; j < dtTable.Columns.Count; j++)
                    {
                        currRow.Add(dtTable.Rows[i][j]);
                    }
                    resultArrayList.Add(currRow);
                }
            }

            return resultArrayList;
        }

        /// <summary>
        /// Converts a DataTable to a list of specified type.
        /// </summary>
        /// <typeparam name="T">The type of items in the returned list.</typeparam>
        /// <param name="dataTable">The DataTable to convert.</param>
        /// <returns>A list of items of the specified type.</returns>
        public static List<T> DataTableToArrayList<T>(DataTable dataTable) where T : new()
        {
            List<T> list = null;

            if (dataTable != null)
            {
                list = new List<T>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    T item = CreateItemFromRow<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        /// <summary>
        /// Converts a DataTable to a single business object of specified type.
        /// </summary>
        /// <typeparam name="T">The type of the business object.</typeparam>
        /// <param name="dataTable">The DataTable to convert.</param>
        /// <returns>A business object of the specified type.</returns>
        public static T DataTableToBusinessObject<T>(DataTable dataTable) where T : new()
        {
            T obj = default;

            if (dataTable != null)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    obj = CreateItemFromRow<T>(row);
                }
            }

            return obj;
        }

        /// <summary>
        /// Creates an object of the specified type from a DataRow.
        /// </summary>
        /// <typeparam name="T">The type of the object to create.</typeparam>
        /// <param name="row">The DataRow to convert.</param>
        /// <returns>An object of the specified type.</returns>
        private static T CreateItemFromRow<T>(DataRow row) where T : new()
        {
            T obj = default;

            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        if (prop != null)
                        {
                            object value = row[column.ColumnName];
                            if (value != null)
                            {
                                value = value.ToString().Trim();
                                if (value.GetType() != typeof(DBNull) && Convert.ToString(value) != string.Empty)
                                {
                                    SetValue(prop, obj, value);
                                }
                                else
                                {
                                    prop.SetValue(obj, null, null);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error setting property '{prop?.Name}' with value '{row[column.ColumnName]}'.", ex);
                    }
                }
            }

            return obj;
        }

        /// <summary>
        /// Sets the value to the specified property.
        /// </summary>
        private static void SetValue<T>(PropertyInfo prop, T obj, object value)
        {
            if (prop.PropertyType == typeof(Nullable<int>))
            {
                prop.SetValue(obj, Convert.ToInt32(value), null);
            }
            else if (prop.PropertyType == typeof(int))
            {
                prop.SetValue(obj, Convert.ToInt32(Math.Round(Convert.ToDecimal(value))), null);
            }
            else if (prop.PropertyType == typeof(Nullable<DateTime>) || prop.PropertyType == typeof(DateTime))
            {
                string format = "MM/dd/yyyy HH:mm:ss.fff";
                DateTime dateValue = DateTime.ParseExact(
                    Convert.ToDateTime(value).ToString(format, System.Globalization.CultureInfo.InvariantCulture),
                    format,
                    System.Globalization.CultureInfo.InvariantCulture);
                prop.SetValue(obj, dateValue, null);
            }
            else if (prop.PropertyType == typeof(Nullable<char>))
            {
                prop.SetValue(obj, Convert.ToChar(value), null);
            }
            else if (prop.PropertyType == typeof(bool))
            {
                prop.SetValue(obj, Convert.ToBoolean(value), null);
            }
            else
            {
                prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType), null);
            }
        }

        public static List<T> ConvertToList<T>(ArrayList list)
        {
            List<T> ret = new List<T>();
            if (list != null)
            {
                foreach (T item in list)
                {
                    ret.Add(item);
                }
            }
            return ret;
        }

        public static List<T> ConvertToList<T>(IList list)
        {
            List<T> ret = new List<T>();
            if (list != null)
            {
                foreach (T item in list)
                {
                    ret.Add(item);
                }
            }
            return ret;
        }

        public static T CreateItemFromRow1<T>(DataRow row) where T : new()
        {
            T obj = new T();
            for (int i = 0; i < row.Table.Columns.Count; i++)
            {
                DataColumn column = row.Table.Columns[i];
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
                try
                {
                    if (props[column.ColumnName] != null)
                    {
                        object value = row[column.ColumnName];
                        if (value != null)
                        {
                            value = value.ToString().Trim();
                            if (value.GetType() != typeof(DBNull) && Convert.ToString(value) != string.Empty)
                            {
                                if (props[column.ColumnName].PropertyType == typeof(Nullable<Int32>))
                                {
                                    props[column.ColumnName].SetValue(obj, Convert.ToInt32(value));
                                }
                                else if (props[column.ColumnName].PropertyType == typeof(Int32))
                                {
                                    props[column.ColumnName].SetValue(obj, Convert.ToInt32(Math.Round(Convert.ToDecimal(value))));
                                }
                                else if (props[column.ColumnName].PropertyType == typeof(Nullable<Int64>))
                                {
                                    props[column.ColumnName].SetValue(obj, Convert.ToInt64(value));
                                }
                                else if (props[column.ColumnName].PropertyType == typeof(Int64))
                                {
                                    props[column.ColumnName].SetValue(obj, Convert.ToInt64(Math.Round(Convert.ToDecimal(value))));
                                }
                                else if (props[column.ColumnName].PropertyType == typeof(Nullable<DateTime>))
                                {
                                    value = Convert.ToDateTime(row[column.ColumnName]).ToString("MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                                    props[column.ColumnName].SetValue(obj, DateTime.ParseExact(value.ToString(), "MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture));
                                }
                                else if (props[column.ColumnName].PropertyType == typeof(DateTime))
                                {
                                    value = Convert.ToDateTime(row[column.ColumnName]).ToString("MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                                    props[column.ColumnName].SetValue(obj, DateTime.ParseExact(value.ToString(), "MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture));
                                }
                                else if (props[column.ColumnName].PropertyType == typeof(Nullable<char>))
                                {
                                    props[column.ColumnName].SetValue(obj, Convert.ToChar(value));
                                }
                                else if (props[column.ColumnName].PropertyType == typeof(Boolean))
                                {
                                    int result = 0;
                                    if (int.TryParse(Convert.ToString(value), out result))
                                    {
                                        value = int.Parse(Convert.ToString(value));
                                    }
                                    props[column.ColumnName].SetValue(obj, Convert.ToBoolean(value));
                                }
                                else
                                {
                                    props[column.ColumnName].SetValue(obj, Convert.ChangeType(value, props[column.ColumnName].PropertyType));
                                }
                            }
                            else
                            {
                                props[column.ColumnName].SetValue(obj, null);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public static List<T> DataTableToArrayLst<T>(DataTable dataTable) where T : new()
        {
            List<T> list = null;
            if (dataTable != null)
            {
                list = new List<T>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    T item = CreateItemFromRow<T>(row);
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// This method is used to cast any datatable into arraylist which contains items of specific DataType.
        /// </summary>
        /// <typeparam name="T">It can be any type which want to be in return arraylist</typeparam>
        /// <param name="dataTable">Datatable which will be casted into arraylist.</param>
        /// <returns>returns arrylist which is generated by using given Datatable and Type.</returns>
        public static List<T> DataTableToList<T>(DataTable dataTable) where T : new()
        {
            List<T> list = null;
            if (dataTable != null)
            {
                list = new List<T>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    T item = CreateItemFromRow<T>(row);
                    list.Add(item);
                }
            }
            return list;
        }

    }
}
