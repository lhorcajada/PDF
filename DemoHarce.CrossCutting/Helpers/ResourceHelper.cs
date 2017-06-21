using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoHarce.CrossCutting.Helpers
{
    public class ResourceHelper
    {
        public static string GetResourceLookup(Type resourceType, string resourceName)
        {
            if ((resourceType != null) && (resourceName != null))
            {
                PropertyInfo property = resourceType.GetProperty(resourceName, BindingFlags.Public | BindingFlags.Static);
                if (property == null)
                {
                    throw new InvalidOperationException(string.Format("Resource Type Does Not Have Property"));
                }
                if (property.PropertyType != typeof(string))
                {
                    throw new InvalidOperationException(string.Format("Resource Property is Not String Type"));
                }
                return (string)property.GetValue(null, null);
            }
            return null;
        }
    }
}
