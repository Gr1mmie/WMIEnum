using System.Text;
using System.Management;
using System.Collections.Generic;

namespace WMIEnum.Commands
{
    class ReturnAllGroupMembers : Models.Command
    {
        public override string CommandName => "AllGroupMembers";

        public override string Description => "Return all groups and their members";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            string cProp = null;
            string cUser = null;
            string cGroup = null;

            List<string> groups = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_GroupUser");
            foreach (ManagementObject obj in searcher.Get()) {
                foreach(var prop in obj.Properties) {
                    cProp = prop.Value.ToString();
                    if (cProp.Contains("Group")) {
                        var group = cProp.Split('=')[2].Split('"')[1];
                        if (!groups.Contains(group)) { groups.Add(group); }
                    }
                }
            }

            var groupArr = groups.ToArray();

            for (int i = 0; i < groupArr.Length; i++) {
                List<string> users = new List<string>();

                outData.AppendLine($"Group: {groupArr[i]}");
                ManagementObjectSearcher searcher2 = new ManagementObjectSearcher("Select * From Win32_GroupUser");
                foreach (ManagementObject obj in searcher2.Get()) {
                    foreach (var prop in obj.Properties) {
                        cProp = prop.Value.ToString();
                        if (cProp.Contains("UserAccount") || cProp.Contains("SystemAccount")) {
                            cUser = cProp.Split('=')[2].Split('"')[1];
                        }

                        if (cProp.Contains("Group")) { cGroup = cProp.Split('=')[2].Split('"')[1]; }
                       
                        if (cGroup == groupArr[i]){ if (!users.Contains(cUser) && cUser != null) { users.Add(cUser); } }
                    }
                }
                var userArr = users.ToArray();
                for (int j = 0; j < userArr.Length; j++) { outData.AppendLine($"\t{userArr[j]}"); }
                outData.AppendLine();
            }

            return outData.ToString();
        }
    }
}
