using System;
using System.Text;

using WMIEnum.Models;

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

                if (args.Length != 1) { throw new WMIEnumException("[*] TargetInstalledPrograms [ProgramName]"); }

                cProgram = args[0];

                string[] fields = new string[] { "Name", "Version" };

                outData = Utils.Extensions.Extensions.ObjProperties(outData, fields,
                    $"SELECT * FROM Win32_Product Where Name Like '%{cProgram}%'");

                return outData.ToString();
            } catch (WMIEnumException e) { return e.Message; }
        }
    }
}
