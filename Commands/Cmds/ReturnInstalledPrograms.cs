using System.Text;
using System.Management;

using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands
{
    class ReturnInstalledPrograms : Models.Command
    {
        public override string CommandName => "InstalledPrograms";

        public override string Description => "Return installed programs";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();
            ManagementObjectSearcher searcher = null;

            string[] fields = new string[] { "Name", "Version" };

            if (ConnObj != null) { searcher = Extensions.AuthSearcher("SELECT * FROM Win32_Product");
            } else { searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Product"); }

            return Extensions.ObjProperties(outData, fields, searcher);
        }
    }
}
