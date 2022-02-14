using System.Text;

using static WMIEnum.Utils.Extensions.Extensions;

namespace WMIEnum.Commands.Cmds
{
    class ReturnComputerName : Models.Command
    {
        public override string CommandName => "ComputerName";

        public override string Description => "Return computer name";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine(FetchComputerName());

            return outData.ToString();
        }
    }
}
