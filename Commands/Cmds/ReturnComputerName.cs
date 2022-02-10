using System.Text;
using System.Management;

namespace WMIEnum.Commands.Cmds
{
    class ReturnComputerName : Models.Command
    {
        public override string CommandName => "ComputerName";

        public override string Description => "Return computer name";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From CIM_OperatingSystem");
            foreach(ManagementObject obj in searcher.Get()) { outData.Append($"Computer Name: {obj["CSName"]}"); }
            outData.AppendLine();

            return outData.ToString();
        }
    }
}
