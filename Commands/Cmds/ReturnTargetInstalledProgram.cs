using System.Text;
using System.Management;

using WMIEnum.Models;
using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands
{
    class ReturnTargetInstalledProgram : Models.Command
    {
        private string cProgram { get; set; }
        public override string CommandName => "TargetInstalledPrograms";

        public override string Description => "Returns a specific program";

        public override string CommandExec(string[] args)
        {
            try {
                StringBuilder outData = new StringBuilder();
                ManagementObjectSearcher searcher = null;

                if (args.Length != 2) { throw new WMIEnumException("[*] TargetInstalledPrograms [ProgramName]"); }

                cProgram = args[1];

                string[] fields = new string[] { "Name", "Version" };

                if (ConnObj != null) { searcher = Extensions.AuthSearcher($"SELECT * FROM Win32_Product Where Name Like '%{cProgram}%'");
                } else { searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_Product Where Name Like '%{cProgram}%'"); }

                return Extensions.ObjProperties(outData, fields, searcher);
            } catch (WMIEnumException e) { return e.Message; }
        }
    }
}
