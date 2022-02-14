using System.Text;
using System.Management;

using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands
{
    class ReturnGroups : Models.Command
    {
        public override string CommandName => "Groups";

        public override string Description => "Return all groups";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();
            ManagementObjectSearcher searcher = null;

            string[] fields = new string[] { "Name", "Caption", "Description", "LocalAccount", "Status", "SID", "SIDType" };

            if (ConnObj != null) { searcher = Extensions.AuthSearcher("SELECT * FROM Win32_Group");
            } else { searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Group"); }

            return Extensions.ObjProperties(outData, fields, searcher);
        }
    }
}
