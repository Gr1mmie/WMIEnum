using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SharpCIMEnum.Commands.Cmds
{
    class ReturnPhysicalDisks : Models.Command
    {
        public override string CommandName => "PhysicalDisks";

        public override string Description => "Returns physical disks";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            string[] fields = new string[] { "Description", "Compressed", "SystemName", "Size", "FreeSpace", 
                "FileSystem", "DriveType", "MediaType", "SupportsFileBasedCompression", "Access" };

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_LogicalDisk");
            foreach( ManagementObject obj in searcher.Get() ) {
                outData.AppendLine($"Name : {obj["Name"]}");
                foreach (var prop in obj.Properties) {
                    if (fields.Contains(prop.Name)) { outData.AppendLine(($"{prop.Name} : {prop.Value}").ToString()); }
                }
                outData.AppendLine();
            }

            return outData.ToString();
        }
    }
}
