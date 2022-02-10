using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIEnum.Commands
{
    class Exit : Models.Util
    {
        public override string UtilName => "Exit";

        public override string Description => "Exits WMIEnum";

        public override string UtilExec(string[] args)
        {
            Environment.Exit(0); 
            return "";
        }
    }
}