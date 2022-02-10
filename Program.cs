using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WMIEnum.Utils.UI;

using static System.Console;

namespace WMIEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.Banner();

            while (true) {

                Write("> ");
                var ui = ReadLine();

                UI.Action(ui);
            }
        }
    }
}
