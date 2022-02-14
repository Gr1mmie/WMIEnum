using System.Text;
using System.Management;

using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands.Cmds
{
    class ReturnLoggedinUsers : Models.Command
    {
        public override string CommandName => "LoggedinUsers";

        public override string Description => "Returns all users currently logged";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();
            ManagementObjectSearcher searcher = null;

            if (ConnObj != null) { searcher = Extensions.AuthSearcher("Select * From Win32_LoggedOnUser");
            } else { searcher = new ManagementObjectSearcher("Select * From Win32_LoggedOnUser"); }

            return UserOps.FetchCurrentUsers(outData, searcher);
        }
    }
}
