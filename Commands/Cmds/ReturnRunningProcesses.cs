using System.Text;
using System.Management;

using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands.Cmds
{
    class ReturnRunningProcesses : Models.Command
    {
        public override string CommandName => "Processes";

        public override string Description => "return all running process";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();
            ManagementObjectSearcher searcher = null;

            string[] fields = new string[] { "Name", "ProcessId", "SessionId" };


            if (ConnObj != null) { searcher = Extensions.AuthSearcher("SELECT * FROM Win32_Process");
            } else { searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process"); }

            return Extensions.ObjProperties(outData, fields, searcher).ToString();
        }
    }
}
