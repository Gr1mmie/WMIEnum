using WMIEnum.Utils.UI;

using static System.Console;

using static WMIEnum.Models.Data;

namespace WMIEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.Banner();

            while (true) {

                if (ConnObj != null && !(Prompt.Contains($"{ConnObj.Username}"))) { Prompt = $"[{ComputerName}\\{ConnObj.Username}] > "; }

                Write($"{Prompt}");
                var ui = ReadLine();

                UI.Action(ui);
            }
        }
    }
}
