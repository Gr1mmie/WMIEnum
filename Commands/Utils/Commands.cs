using WMIEnum.Utils.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static WMIEnum.Models.Data;

namespace WMIEnum.Commands
{
    public class Commands : Models.Util
    {
        public override string UtilName => "Commands";

        public override string Description => "List available commands";

        public override string UtilExec(string[] args)
        {
            StringBuilder _out = new StringBuilder();

            if (_commands.Count == 0) { Init.CommandInit(); }
            if (_utils.Count == 0) { Init.UtilInit(); }

            var commands = new List<Models.Command>();

            _out.AppendLine("\nCommands\n____________\n");
            foreach (Models.Command cmd in _commands){
                _out.AppendLine($"{cmd.CommandName,-25} {cmd.Description}");
            }

            _out.AppendLine("\nUtils\n____________\n");
            foreach (Models.Util util in _utils)
            {
                _out.AppendLine($"{util.UtilName,-25} {util.Description}");
            }

            return _out.ToString();
        }
    }
}
