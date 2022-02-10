using System.Text;

namespace WMIEnum.Commands
{
    class ReturnGroups : Models.Command
    {
        public override string CommandName => "Groups";

        public override string Description => "Return all groups";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            string[] fields = new string[] { "Name", "Caption", "Description", "LocalAccount", "Status", "SID", "SIDType" };

            outData = Utils.Extensions.Extensions.ObjProperties(outData, fields, "SELECT * FROM Win32_Group");

            return outData.ToString();
        }
    }
}
