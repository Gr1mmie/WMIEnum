using System;
using System.Text;
using System.Management;

using WMIEnum.Models;

using static WMIEnum.Models.Data;


namespace WMIEnum.Commands
{
    internal class Authenticate : Models.Util
    {
        private string ComputerName { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }
        public override string UtilName => "Authenticate";

        public override string Description => "Authenticate to remote machine";

        public override string UtilExec(string[] args)
        {
            try {

                if(args is null || args.Length != 4) { throw new WMIEnumException("[-] Usage: Authenticate [Computer name] [username] [password]"); }

                ComputerName = args[1];
                UserName = args[2];
                Password = args[3];

                StringBuilder outData = new StringBuilder();

                ConnectionOptions opts = new ConnectionOptions();
                opts.Impersonation = ImpersonationLevel.Impersonate;

                opts.Username = $"{UserName}";
                opts.Password = $"{Password}";

                ManagementScope scope = new ManagementScope($"\\\\{ComputerName}\\{NameSpace}", opts);
                scope.Connect();

                ConnObj = opts;

                Data.ComputerName = ComputerName;

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject obj in searcher.Get()) { outData.Append($"Computer Name: {obj["CSName"]}"); }
                outData.AppendLine();

                return $"[*] Credential object created for user {ConnObj.Username}";
            } catch (UnauthorizedAccessException) { return "[-] Incorrect credentials passed"; }
            catch (WMIEnumException e) { return e.Message; }
        }
    }
}
