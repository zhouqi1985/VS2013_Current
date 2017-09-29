using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PetFeedEvents.Database.Database
{
    public class BaseEntity
    {
    
        public override string ToString()
        {
            
            StringBuilder output = new StringBuilder();
            Type t = this.GetType();
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(this, null);
                output.AppendFormat(":{0}={1}", property.Name, value);
            }
            return output.ToString();
        }
    }
}
