using System.Text;
using System.Management;

using WMIEnum.Utils.Extensions;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands.Cmds
{
    class ReturnPhysicalDisks : Models.Command
    {
        public override string CommandName => "PhysicalDisks";

        public override string Description => "Returns physical disks";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();
            ManagementObjectSearcher searcher = null;

            string[] fields = new string[] { "Description", "Compressed", "SystemName", "Size", "FreeSpace", 
                "FileSystem", "DriveType", "MediaType", "SupportsFileBasedCompression", "Access" };

            if (ConnObj != null) { searcher = Extensions.AuthSearcher("Select * From Win32_LogicalDisk");
            } else { searcher = new ManagementObjectSearcher("Select * From Win32_LogicalDisk"); }

            return DiskOps.FetchPhysicalDisks(outData, fields, searcher).ToString();
        }
    }
}
