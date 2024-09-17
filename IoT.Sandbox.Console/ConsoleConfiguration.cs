namespace IoT.Sandbox.Console
{
    public class ConsoleConfiguration
    {
        public string? Environment { get; set; }

        public LogLevel? LogLevel { get; set; }

        public string? Run { get; set; }
    }

    public class LogLevel
    {
        public string? Console { get; set; }
    }
}
