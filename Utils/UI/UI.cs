﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using SharpCIMEnum.Models;

using SharpCIMEnum.Utils;

using static System.Console;

using static SharpCIMEnum.Models.Data;

namespace SharpCIMEnum.Utils.UI
{
    class UI
    {
        public static void Banner()
        {
            Console.WriteLine(
                "  _      ____  ___________              \n" +
                " | | /| / /  |/  /  _/ __/__  __ ____ _ \n" +
                " | |/ |/ / /|_/ // // _// _ \\/ // /  ' \\\n" +
                " |__/|__/_/  /_/___/___/_//_/\\_,_/_/_/_/\n"
                );
        }

        public static void Action(string input)
        {
            try
            {

                //if (input is "") { throw new AtlasException(""); }

                String[] opts = null;
                string _out = null;
                
                if (_commands.Count == 0) { Init.CommandInit(); }
                if (_utils.Count == 0) { Init.UtilInit(); }

                Command cmd = _commands.FirstOrDefault(u => u.CommandName.Equals(input.Split(' ')[0], StringComparison.InvariantCultureIgnoreCase));
                Util util = _utils.FirstOrDefault(u => u.UtilName.Equals(input.Split(' ')[0], StringComparison.InvariantCultureIgnoreCase));
                if (cmd is null && util is null) { throw new CIMEnumException($"[-] Command {input} is invalid"); }

                if (input.Contains(' ')) { opts = input.Split(' '); }

                if (cmd is null) { _out = util.UtilExec(opts);
                } else { _out = cmd.CommandExec(opts); }

                WriteLine(_out);
            }
            catch (NotImplementedException) { WriteLine($"[-] Util {input} not yet implemented"); }
            catch (CIMEnumException e) { WriteLine(e.Message); }
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