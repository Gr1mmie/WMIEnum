using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SharpCIMEnum.Commands
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

                ProcName = "Runtime";

                string[] fields = new string[] { "Name", "ProcessId", "SessionId" };

                outData = Utils.Extensions.Extensions.ObjProperties(outData, fields,
                    $"SELECT * FROM Win32_Process Where Name Like '%{ProcName}%'");

                return outData.ToString();
            } catch (Exception e) { return ""; }
        }
    }
}
