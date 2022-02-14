using System.Text;
using System.Management;

using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands
{
    class ReturnOSInfo : Models.Command
    {
        public override string CommandName => "OSInfo";

        public override string Description => "Queries OS information";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();
            ManagementObjectSearcher searcher = null;

            string[] fields = new string[] { "Caption", "InstallDate", "CSName", "Version", "BuildNumber", "OSArchitecture",
                "LastBootUpTime", "NumberOfUsers"};

            if (ConnObj != null) { searcher = Extensions.AuthSearcher("SELECT * FROM CIM_OperatingSystem");
            } else { searcher = new ManagementObjectSearcher("SELECT * FROM CIM_OperatingSystem"); }

            return Extensions.ObjProperties(outData, fields, searcher).ToString();
        }
    }
}
