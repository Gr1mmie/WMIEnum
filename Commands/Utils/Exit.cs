using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCIMEnum.Commands
{
    class Exit : Models.Util
    {
        public override string UtilName => "Exit";

        public override string Description => "Exits SharpCIMEnum";

        public override string UtilExec(string[] args)
        {
            Environment.Exit(0); 
            return "";
        }
    }
}