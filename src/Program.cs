using WebSocketSharp.Server;
using Utils;

namespace WebsocketServer
{
  public class Chat : WebSocketBehavior
  {
    private string name = Strings.RandomName();

    protected override void OnOpen()
    {
      Logger.Info($"A client has connected, it's name is: '{name}'");
    }

    protected override void OnClose(WebSocketSharp.CloseEventArgs e)
    {
      Logger.Info($"Client '{name}' has disconnected");
    }

    protected override void OnMessage(WebSocketSharp.MessageEventArgs evt)
    {
      Logger.Info($"Received a message from {name}: '{evt.Data}'");
      Sessions.Broadcast(evt.Data);
    }
  }



  class Program
  {
    public static void Main(string[] args)
    {
      var webSocketServer = new WebSocketServer("ws://localhost:8080");

      webSocketServer.AddWebSocketService<Chat>("/echo");

      webSocketServer.Start();
      Logger.Info("Server started on 'ws://localhost:8080/'");

      Console.ReadKey(true);
      webSocketServer.Stop();
    }
  }
}
