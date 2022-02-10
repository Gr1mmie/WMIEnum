using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMIEnum.Commands
{
    class ReturnOSInfo : Models.Command
    {
        public override string CommandName => "OSInfo";

        public override string Description => "Queries OS information";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            string[] fields = new string[] { "Caption", "InstallDate", "CSName", "Version", "BuildNumber", "OSArchitecture",
                "LastBootUpTime", "NumberOfUsers"};

            outData = Utils.Extensions.Extensions.ObjProperties(outData, fields, "SELECT * FROM CIM_OperatingSystem");

            return outData.ToString();
        }
    }
}
