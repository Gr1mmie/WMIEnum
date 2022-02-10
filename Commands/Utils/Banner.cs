using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCIMEnum.Commands
{
    internal class Banner : Models.Util
    {
        public override string UtilName => "Banner";

        public override string Description => "Prints banner";

        public override string UtilExec(string[] args)
        {

            StringBuilder banner = new StringBuilder();

            banner.AppendLine(
                "  _      ____  ___________                \n" +
                " | | /| / /  |/  /  _/ __/__  __ ____ _   \n" +
                " | |/ |/ / /|_/ // // _// _ \\/ // /  ' \\\n" +
                " |__/|__/_/  /_/___/___/_//_/\\_,_/_/_/_/ \n"
                );

            return banner.ToString();
        }
    }
}
