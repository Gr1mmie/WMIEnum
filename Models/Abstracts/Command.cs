namespace WMIEnum.Models
{
    public abstract class Command
    {
        public abstract string CommandName { get; }
        public abstract string Description { get; }
        public abstract string CommandExec(string[] args);
    }
}