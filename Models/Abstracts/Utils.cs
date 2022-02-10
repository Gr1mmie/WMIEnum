namespace SharpCIMEnum.Models
{
    public abstract class Util
    {
        public abstract string UtilName { get; }
        public abstract string Description { get; }
        public abstract string UtilExec(string[] args);
    }
}
