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

                Write(" > ");
                var ui = ReadLine();

                UI.Action(ui);
            }
        }
    }
}
