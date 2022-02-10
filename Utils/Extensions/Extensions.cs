using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace WMIEnum.Utils.Extensions
{
    class Extensions
    {
        public static StringBuilder ObjProperties(StringBuilder sb, string[] fields, ManagementObject obj)
        {
            foreach (var prop in obj.Properties){
                if (fields.Contains(prop.Name)) { sb.AppendLine(($"{prop.Name} : {prop.Value}").ToString()); }
            }

            return sb;
        }

        public static StringBuilder ObjProperties(StringBuilder sb, string[] fields, string WMIQuery)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(WMIQuery);
            foreach (ManagementObject obj in searcher.Get())
            {
                foreach (var prop in obj.Properties) {
                    if (fields.Contains(prop.Name)) { sb.AppendLine(($"{prop.Name} : {prop.Value}").ToString()); }
                }
                sb.AppendLine();
            }

            return sb;
        }
    }
}
