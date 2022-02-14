using System.Text;
using System.Management;

using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands
{
    class ReturnUsers : Models.Command
    {
        public override string CommandName => "ReturnUsers";

        public override string Description => "return users on a machine";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();
            ManagementObjectSearcher searcher = null;

            string[] fields = new string[] { "Name", "Caption", "FullName", "Description", "LocalAccount", "Status0", 
                "Domain", "AccountType", "SID"};

            if (ConnObj != null) {
                searcher = Extensions.AuthSearcher("Select * From Win32_UserAccount");
            } else { searcher = new ManagementObjectSearcher("Select * From Win32_UserAccount"); }

            return Extensions.ObjProperties(outData, fields, searcher).ToString();
        }
    }
}
