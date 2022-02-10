using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMIEnum.Commands
{
    class ReturnUsers : Models.Command
    {
        public override string CommandName => "ReturnUsers";

        public override string Description => "return users on a machine";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();
            
            string[] fields = new string[] { "Name", "Caption", "FullName", "Description", "LocalAccount", "Status0", 
                "Domain", "AccountType", "SID"};

            outData = Utils.Extensions.Extensions.ObjProperties(outData, fields, "Select * From Win32_UserAccount");

            return outData.ToString();
        }
    }
}
