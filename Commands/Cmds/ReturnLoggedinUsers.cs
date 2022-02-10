using System.Management;
using System.Text;

namespace SharpCIMEnum.Commands.Cmds
{
    class ReturnLoggedinUsers : Models.Command
    {
        public override string CommandName => "LoggedinUsers";

        public override string Description => "Returns all users currently logged";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            string cProp;
            string cUser = null;
            string cLogonId = null;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_LoggedOnUser");
            foreach (ManagementObject obj in searcher.Get()) {
                foreach (var prop in obj.Properties) {
                    cProp = prop.Value.ToString();
                    if(cProp.Contains("Account")) { cUser = cProp.Split('=')[2].Split('"')[1]; }
                    if(cProp.Contains("LogonId")) { cLogonId = cProp.Split('=')[1].Split('"')[1]; }
                }
                outData.AppendLine($"User : {cUser}");
                outData.AppendLine($"LogonId : {cLogonId}");
                outData.AppendLine();
            }

            return outData.ToString();
        }
    }
}
