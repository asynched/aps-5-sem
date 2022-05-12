using WebSocketSharp.Server;
using Utils;

namespace WebsocketServer
{
  class Program
  {
    public static void Main(string[] args)
    {
      var webSocketServer = new WebSocketServer("ws://localhost:8080");
      webSocketServer.AddWebSocketService<Services.WebSocketService>("/");

      webSocketServer.Start();
      Logger.Info("Server started on 'ws://localhost:8080/'");

      while (true)
      {
        char key = Console.ReadKey(true).KeyChar;

        switch (key)
        {
          case 'r':
            {
              Logger.Warn("Restarting server...");
              webSocketServer.Stop();
              webSocketServer.Start();
              break;
            }
          case 's':
            {
              Logger.Warn("Stopping server...");
              webSocketServer.Stop();
              Logger.Info("Server stopped successfully.");
              System.Environment.Exit(0);
              break;
            }
        }
      }
    }
  }
}
