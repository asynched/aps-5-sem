using System.Text.Json;
using WebSocketSharp.Server;
using Utils;
using Models;

namespace Services
{
  public class WebSocketService : WebSocketBehavior
  {
    /// <summary>
    /// Field to indicate the current connection id
    /// </summary>
    public string Id = Guid.NewGuid().ToString();

    /// <summary>
    /// Field to indicate the current connection username
    /// </summary>
    public string Name = Strings.RandomName();

    /// <summary>
    /// Static member that stores the current connected clients.
    /// </summary>
    public static List<WebSocketService> Clients { get; set; } = new List<WebSocketService>();

    protected override void OnOpen()
    {
      // Log that a new client has connected and append it
      // to the list of connected clients.
      Logger.Info($"Client '{Name}' has connected.");
      Clients.Add(this);

      // Broadcast to all connected clients that a new one has connected. This
      // This sends a list of connected clients to the frontend to be displayed.
      this.Sessions.Broadcast(ConnectedClientsMessage.FromWebSocket(Clients).ToJson());
      this.Send(ConnectedClientsMessage.FromWebSocket(Clients).ToJson());
      this.Send(RegistrationMessage.FromUsername(Name).ToJson());
    }

    protected override void OnMessage(WebSocketSharp.MessageEventArgs evt)
    {
      var message = evt.Data;
      var chatMessage = new ChatMessage(new Chat(this.Id, message, this.Name, DateTime.Now.ToString()));

      Logger.Info($"Client '{Name}' sent message: '{message}'");
      this.Sessions.Broadcast(chatMessage.ToJson());
    }

    protected override void OnClose(WebSocketSharp.CloseEventArgs evt)
    {
      // Logs that a client has disconnected and removes it from the list of
      // connected clients.
      Logger.Warn($"Client '{Name}' has disconnected.");
      Clients.Remove(this);

      // Creates a new disconnection message and serializes it to string.
      var disconnection = new Disconnection(Guid.NewGuid().ToString(), $"{Name} has disconnected.", Name, DateTime.Now.ToString());
      var message = JsonSerializer.Serialize(new DisconnectionMessage(disconnection));

      // Broadcasts the disconnection message to the clients and sends a
      // revalidation message to the frontend.
      this.Sessions.Broadcast(message);
      this.Sessions.Broadcast(ConnectedClientsMessage.FromWebSocket(Clients).ToJson());
    }
  }
}
