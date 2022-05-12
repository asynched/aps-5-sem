namespace Utils
{
  public class Logger
  {
    static bool displayDebugLogs = false;

    public static void Log(string level, string message)
    {
      var currentDate = DateTime.Now;
      var parsedLevel = $"{level}".PadLeft(5);
      Console.WriteLine($"{currentDate}\t{parsedLevel}\t{message}");
    }

    public static void Info(string message)
    {
      Log("INFO", message);
    }

    public static void Error(string message)
    {
      Log("ERROR", message);
    }

    public static void Debug(string message)
    {
      Log("DEBUG", message);
    }

    public static void Warn(string message)
    {
      Log("WARN", message);
    }
  }

}