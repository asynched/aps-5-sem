using WebSocketSharp.Server;
using Utils;

namespace WebsocketServer
{
  class Program
  {
    public static void Main(string[] args)
    {
      var websocketAddress = "ws://localhost:8080";
      var webSocketServer = new WebSocketServer(websocketAddress);
      webSocketServer.AddWebSocketService<Services.WebSocketService>("/");

      webSocketServer.Start();
      Logger.Info($"Server started on '{websocketAddress}'");

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
