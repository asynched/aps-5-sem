using System.Text.Json;
using System.Text.Json.Serialization;
using Services;

namespace Models
{
  public class Client : Serializable
  {
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }

    public Client(string id, string name)
    {
      this.Id = id;
      this.Name = name;
    }

    public string ToJson()
    {
      return JsonSerializer.Serialize(this);
    }
  }

  public class ConnectedClientsMessage : JsonMessage<List<Client>>
  {
    public static ConnectedClientsMessage FromWebSocket(List<WebSocketService> clients)
    {
      return new ConnectedClientsMessage(clients.Select(Client => new Client(Client.Id, Client.Name)).ToList());
    }

    public ConnectedClientsMessage(List<Client> data) : base("CONNECTED_CLIENTS", data)
    {
    }
  }
}
