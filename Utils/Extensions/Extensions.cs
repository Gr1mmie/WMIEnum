using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

using static WMIEnum.Models.Data;

namespace WMIEnum.Utils.Extensions
{
    public class Extensions
    {
        public static ManagementObjectSearcher AuthSearcher(string query) {
            ManagementScope scope = new ManagementScope($"\\\\{ComputerName}\\{NameSpace}", ConnObj);
            ObjectQuery oQuery = new ObjectQuery(query);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, oQuery);
            return searcher;
        }

        public static string FetchComputerName() {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From CIM_OperatingSystem");
            foreach (ManagementObject obj in searcher.Get()) { ComputerName = $"{obj["CSName"]}"; }
            return ComputerName;
        }

        public static string ObjProperties(StringBuilder sb, string[] fields, ManagementObjectSearcher searcher) {
            foreach (ManagementObject obj in searcher.Get()) {
                foreach (var prop in obj.Properties) {
                    if (fields.Contains(prop.Name)) { sb.AppendLine(($"{prop.Name} : {prop.Value}").ToString()); }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static string ObjProperties(StringBuilder sb, string[] fields, string WMIQuery) {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(WMIQuery);
            foreach (ManagementObject obj in searcher.Get())
            {
                foreach (var prop in obj.Properties) {
                    if (fields.Contains(prop.Name)) { sb.AppendLine(($"{prop.Name} : {prop.Value}").ToString()); }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    public class DiskOps
    {
        public static string FetchPhysicalDisks(StringBuilder sb, string[] fields, ManagementObjectSearcher searcher) {
            foreach (ManagementObject obj in searcher.Get()) {
                sb.AppendLine($"Name : {obj["Name"]}");
                foreach (var prop in obj.Properties) {
                    if (fields.Contains(prop.Name)) { sb.AppendLine(($"{prop.Name} : {prop.Value}").ToString()); }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    public class UserOps
    {
        public static string FetchCurrentUsers(StringBuilder sb, ManagementObjectSearcher searcher) {
            string cProp = null, cUser = null, cLogonId = null;

            foreach (ManagementObject obj in searcher.Get()) {
                foreach (var prop in obj.Properties) {
                    cProp = prop.Value.ToString();
                    if (cProp.Contains("Account")) { cUser = cProp.Split('=')[2].Split('"')[1]; }
                    if (cProp.Contains("LogonId")) { cLogonId = cProp.Split('=')[1].Split('"')[1]; }
                }
                sb.AppendLine($"User : {cUser}");
                sb.AppendLine($"LogonId : {cLogonId}");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }

    public class GroupOps
    {
        public static string FetchGroupMembers(StringBuilder sb, String Group, ManagementObjectSearcher searcher)
        {

            string cProp = null, cUser = null, cGroup = null;

            List<string> users = new List<string>();

            sb.AppendLine($"Group: {Group}");
            foreach (ManagementObject obj in searcher.Get())
            {
                foreach (var prop in obj.Properties)
                {
                    cProp = prop.Value.ToString();
                    if (cProp.Contains("UserAccount") || cProp.Contains("SystemAccount"))
                    {
                        cUser = cProp.Split('=')[2].Split('"')[1];
                    }

                    if (cProp.Contains("Group")) { cGroup = cProp.Split('=')[2].Split('"')[1]; }

                    if (cGroup == Group) { if (!users.Contains(cUser) && cUser != null) { users.Add(cUser); } }
                }
            }
            var userArr = users.ToArray();
            for (int i = 0; i < userArr.Length; i++) { sb.AppendLine($"\t{userArr[i]}"); }

            return sb.ToString();
        }

        public static string FetchAllGroupMembers(StringBuilder sb, ManagementObjectSearcher searcher)
        {

            string cProp = null, cUser = null, cGroup = null;

            List<string> groups = new List<string>();

            foreach (ManagementObject obj in searcher.Get())
            {
                foreach (var prop in obj.Properties)
                {
                    cProp = prop.Value.ToString();
                    if (cProp.Contains("Group"))
                    {
                        var group = cProp.Split('=')[2].Split('"')[1];
                        if (!groups.Contains(group)) { groups.Add(group); }
                    }
                }
            }

            var groupArr = groups.ToArray();

            for (int i = 0; i < groupArr.Length; i++)
            {
                List<string> users = new List<string>();

                sb.AppendLine($"Group: {groupArr[i]}");
                foreach (ManagementObject obj in searcher.Get())
                {
                    foreach (var prop in obj.Properties)
                    {
                        cProp = prop.Value.ToString();
                        if (cProp.Contains("UserAccount") || cProp.Contains("SystemAccount"))
                        {
                            cUser = cProp.Split('=')[2].Split('"')[1];
                        }

                        if (cProp.Contains("Group")) { cGroup = cProp.Split('=')[2].Split('"')[1]; }

                        if (cGroup == groupArr[i]) { if (!users.Contains(cUser) && cUser != null) { users.Add(cUser); } }
                    }
                }
                var userArr = users.ToArray();
                for (int j = 0; j < userArr.Length; j++) { sb.AppendLine($"\t{userArr[j]}"); }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
