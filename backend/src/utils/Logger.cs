namespace Utils
{
  public enum Colors
  {
    RED,
    YELLOW,
    RESET,
    GREEN,
    BLACK,
  }

  static class ColorsExtensions
  {
    public static string GetString(this Colors color)
    {
      switch (color)
      {
        case Colors.RED:
          return "\x1b[31m";
        case Colors.YELLOW:
          return "\x1b[33m";
        case Colors.RESET:
          return "\x1b[0m";
        case Colors.GREEN:
          return "\x1b[32m";
        default:
          return "\u001b[30m";
      }
    }
  }

  public class Logger
  {
    static bool displayDebugLogs = false;

    public static void Log(string level, Colors color, string message)
    {
      var currentDate = DateTime.Now;
      var parsedLevel = $"{level}".PadLeft(5);
      Console.WriteLine($"{currentDate}\t{color.GetString()}{parsedLevel}{Colors.RESET.GetString()}\t{message}");
    }

    public static void Info(string message)
    {
      Log("INFO", Colors.GREEN, message);
    }

    public static void Error(string message)
    {
      Log("ERROR", Colors.RED, message);
    }

    public static void Debug(string message)
    {
      if (displayDebugLogs)
      {
        Log("DEBUG", Colors.YELLOW, message);
      }
    }

    public static void Warn(string message)
    {
      Log("WARN", Colors.YELLOW, message);
    }
  }
}
