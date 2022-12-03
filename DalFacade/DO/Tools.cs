using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DO;

   public static class Tools
    {
        public static string ToStringProperty<T>(this T t)
        {
            string str = " ";
            foreach(PropertyInfo item in typeof(T).GetProperties()) 
            //להתייחס למקרה שמדובר נגיד באוסף ולא באובייקט שטוח?
                str+="/n"+item.Name+": "+item.GetValue(t,null);
            return str; 
        }
    }

