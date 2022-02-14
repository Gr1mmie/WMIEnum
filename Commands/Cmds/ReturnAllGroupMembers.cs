using System.Text;
using System.Management;

using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands
{
    class ReturnAllGroupMembers : Models.Command
    {
        public override string CommandName => "AllGroupMembers";

        public override string Description => "Return all groups and their members";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();
            ManagementObjectSearcher searcher = null;

            if (ConnObj != null) { searcher = Extensions.AuthSearcher("Select * From Win32_GroupUser");
            } else { searcher = new ManagementObjectSearcher("Select * From Win32_GroupUser"); }

            return GroupOps.FetchAllGroupMembers(outData, searcher);
        }
    }
}
