namespace ImportantPrototype.Tools.Console
{
    public interface IConsoleCommand
    {
        public string Name { get; }
        public bool Execute(string[] args);
    }
}
