using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models
{
  /// <summary>
  /// Representation of a chat message sent from
  /// the user within the application
  /// <summary>
  public class Chat : Serializable
  {
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("message")]
    public string Message { get; set; }
    [JsonPropertyName("user")]
    public string User { get; set; }
    [JsonPropertyName("date")]
    public string Date { get; set; }

    public Chat(string id, string message, string user, string date)
    {
      this.Id = id;
      this.Message = message;
      this.User = user;
      this.Date = date;
    }

    public string ToJson()
    {
      return JsonSerializer.Serialize(this);
    }
  }

  public class ChatMessage : JsonMessage<Chat>
  {
    public ChatMessage(Chat data) : base("MESSAGE", data) { }
  }
}
