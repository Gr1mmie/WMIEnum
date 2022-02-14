using System.Text;
using System.Management;

using WMIEnum.Models;
using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

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

                if (args.Length != 2) { throw new WMIEnumException("[*] GroupMembers [GroupName]"); }

                Group = args[1];

                ManagementObjectSearcher searcher = null;

                if(ConnObj != null) { searcher = Extensions.AuthSearcher("Select * From Win32_GroupUser");
                } else { searcher = new ManagementObjectSearcher("Select * From Win32_GroupUser"); }

                return GroupOps.FetchGroupMembers(outData, Group, searcher);
            } catch (WMIEnumException e) { return e.Message; }
        }
    }
}
