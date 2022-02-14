using System.Text;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands
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
                " |__/|__/_/  /_/___/___/_//_/\\_,_/_/_/_/ \n" +
                "\n     Author: Grimmie                    \n" +
                $"      Ver: {Ver}                         \n"
                );

            return banner.ToString();
        }
    }
}
