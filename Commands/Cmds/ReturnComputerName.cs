using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCIMEnum.Commands.Cmds
{
    class ReturnComputerName : Models.Command
    {
        public override string CommandName => "ComputerName";

        public override string Description => "Return computer name";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();



            return outData.ToString();
        }
    }
}
