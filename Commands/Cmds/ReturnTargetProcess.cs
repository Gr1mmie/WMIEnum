using System;
using System.Text;
using System.Management;

using WMIEnum.Models;
using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands
{
    class ReturnTargetProcess : Models.Command
    {
        private string ProcName { get; set; }
        public override string CommandName => "TargetProcess";

        public override string Description => "Returns a specified process";

        public override string CommandExec(string[] args)
        {
            try {
                StringBuilder outData = new StringBuilder();
                ManagementObjectSearcher searcher = null;

                if (args.Length != 2) { throw new WMIEnumException("[*] TargetInstalledPrograms [ProgramName]"); }

                ProcName = args[1];

                string[] fields = new string[] { "Name", "ProcessId", "SessionId" };

                if (ConnObj != null) { searcher = Extensions.AuthSearcher($"SELECT * FROM Win32_Process Where Name Like '%{ProcName}%'");
                } else { searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_Process Where Name Like '%{ProcName}%'"); }

                return Extensions.ObjProperties(outData, fields,searcher).ToString();
            } catch (WMIEnumException e) { return e.Message; }
        }
    }
}
