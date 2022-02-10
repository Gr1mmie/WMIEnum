using System;
using System.Linq;
using System.Reflection;

using WMIEnum.Models;
using WMIEnum.Utils;

using static System.Console;

using static WMIEnum.Models.Data;

namespace WMIEnum.Utils.UI
{
    class UI
    {
        public static void Banner()
        {
            Console.WriteLine(
                "  _      ____  ___________                \n" +
                " | | /| / /  |/  /  _/ __/__  __ ____ _   \n" +
                " | |/ |/ / /|_/ // // _// _ \\/ // /  ' \\\n" +
                " |__/|__/_/  /_/___/___/_//_/\\_,_/_/_/_/ \n" + 
                "\n    Author: Grimmie                     \n"
                );
        }

        public static void Action(string input)
        {
            try
            {

                if (input is "") { throw new WMIEnumException(""); }

                String[] opts = null;
                string _out = null;
                
                if (_commands.Count == 0) { Init.CommandInit(); }
                if (_utils.Count == 0) { Init.UtilInit(); }

                Command cmd = _commands.FirstOrDefault(u => u.CommandName.Equals(input.Split(' ')[0], StringComparison.InvariantCultureIgnoreCase));
                Util util = _utils.FirstOrDefault(u => u.UtilName.Equals(input.Split(' ')[0], StringComparison.InvariantCultureIgnoreCase));
                if (cmd is null && util is null) { throw new WMIEnumException($"[-] Command {input} is invalid"); }

                if (input.Contains(' ')) { opts = input.Split(' '); }

                if (cmd is null) { _out = util.UtilExec(opts);
                } else { _out = cmd.CommandExec(opts); }

                WriteLine(_out);
            }
            catch (NotImplementedException) { WriteLine($"[-] Util {input} not yet implemented"); }
            catch (WMIEnumException e) { WriteLine(e.Message); }
            catch (Exception e) { WriteLine($"{e}"); }
        }
    }

    public class Init
    {
        public static void CommandInit()
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(Command)))
                {
                    Command function = Activator.CreateInstance(type) as Models.Command;
                    _commands.Add(function);
                }
            }
        }

        public static void UtilInit()
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(Util)))
                {
                    Util function = Activator.CreateInstance(type) as Util;
                    _utils.Add(function);
                }
            }

        }
    }
}
