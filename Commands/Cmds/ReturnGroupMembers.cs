using System.Text;
using System.Management;
using System.Collections.Generic;

using WMIEnum.Models;

namespace WMIEnum.Commands
{
    class ReturnGroupMembers : Models.Command
    {
        private string Group { get; set; }
        public override string CommandName => "GroupMembers";

        public override string Description => "Return members of a specified group";

        public override string CommandExec(string[] args)
        {
            try {
                StringBuilder outData = new StringBuilder();

                if (args.Length != 1) { throw new WMIEnumException("[*] GroupMembers [GroupName]"); }

                Group = args[0];

                string cProp;
                string cUser = null;
                string cGroup = null;

                List<string> users = new List<string>();

                outData.AppendLine($"Group: {Group}");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_GroupUser");
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
                for (int i = 0; i < userArr.Length; i++) { outData.AppendLine($"\t{userArr[i]}"); }

                return outData.ToString();
            } catch (WMIEnumException e) { return e.Message; }
        }
    }
}
