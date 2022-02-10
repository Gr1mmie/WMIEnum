using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SharpCIMEnum.Commands
{
    class ReturnInstalledPrograms : Models.Command
    {
        public override string CommandName => "InstalledPrograms";

        public override string Description => "Return installed programs";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            string[] fields = new string[] { "Name", "Version" };

            outData = Utils.Extensions.Extensions.ObjProperties(outData, fields, "SELECT * FROM Win32_Product");

            return outData.ToString();
        }
    }
}
