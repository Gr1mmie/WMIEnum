using System;

namespace SharpCIMEnum.Commands
{
    class Clear : Models.Util
    {
        public override string UtilName => "Clear";

        public override string Description => "Clears the console";

        public override string UtilExec(string[] args)
        {
            Console.Clear();
            return "";
        }
    }
}
