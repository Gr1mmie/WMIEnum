using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SharpCIMEnum.Commands
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

                cProgram = args[0];

                string[] fields = new string[] { "Name", "Version" };

                outData = Utils.Extensions.Extensions.ObjProperties(outData, fields,
                    $"SELECT * FROM Win32_Product Where Name Like '%{cProgram}%'");

                return outData.ToString();
            } catch (Exception ex) { return ""; }
        }
    }
}
