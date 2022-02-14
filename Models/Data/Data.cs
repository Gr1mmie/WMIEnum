using System.Management;
using System.Collections.Generic;

using static WMIEnum.Utils.Extensions.Extensions;

namespace WMIEnum.Models
{
    public class Data {
        public static string NameSpace { get; set; } = "root\\cimv2";
        public static string ComputerName { get; set; } = FetchComputerName();

        public static ConnectionOptions ConnObj { get; set; }

        public static string Prompt = $"[{ComputerName}] > ";
        public const string Ver = "v0.1";

        public static readonly List<Command> _commands = new List<Command>();
        public static readonly List<Util> _utils = new List<Util>();

    }
}