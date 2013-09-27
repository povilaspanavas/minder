using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using Core.Attributes;

/// <summary>
/// Summary description for GridViewHelpers
/// </summary>
namespace WebSite.Helpers
{
    public class GridViewHelper
    {
        public GridViewHelper()
        {
        }

        public DataTable ConvertObjectListToDataTable<T>(List<T> objects)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] properties = typeof(T).GetProperties();
            List<PropertyCaption> captions = GetPropertyCaptions(properties.ToList());

            foreach (PropertyCaption capt in captions)
            {
                dataTable.Columns.Add(capt.Caption);
            }
            dataTable.Columns.Add("Komandos");

            foreach (T obj in objects)
            {
                var values = new object[captions.Count+1];
                for (int i = 0; i < captions.Count+1; i++)
                {
                    if (i == captions.Count)
                        values[i] = string.Empty;
                    else
                    {
                        PropertyInfo property = GetPropertyFromCaption(captions[i], properties.ToList());
                        values[i] = property.GetValue(obj, null);
                    }
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        private PropertyInfo GetPropertyFromCaption(PropertyCaption capt, List<PropertyInfo> properties)
        {
            foreach (PropertyInfo prop in properties)
            {
                if (capt.PropertyName.Equals(prop.Name))
                    return prop;
            }

            return null;
        }

        private List<PropertyCaption> GetPropertyCaptions(List<PropertyInfo> properties)
        {
            List<PropertyCaption> propertyCaptions = new List<PropertyCaption>();

            foreach (PropertyInfo prop in properties)
            {
                object[] attributes = prop.GetCustomAttributes(typeof(PropertyCaption), true);
                if (attributes == null || attributes.Length == 0)
                    continue;
                else
                {
                    PropertyCaption attribute = attributes[0] as PropertyCaption;
                    attribute.PropertyName = prop.Name;
                    propertyCaptions.Add(attribute);
                }

            }

            propertyCaptions = propertyCaptions.OrderBy(M => M.SortValue).ThenBy(N => N.Caption).ToList();
            return propertyCaptions;
        }
    }
}