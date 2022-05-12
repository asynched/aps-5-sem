using System.Text.Json;
using System.Text.Json.Serialization;


namespace Models
{
  public class Disconnection : Serializable
  {
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("message")]
    public string Message { get; set; }
    [JsonPropertyName("user")]
    public string User { get; set; }
    [JsonPropertyName("date")]
    public string Date { get; set; }

    public Disconnection(string id, string message, string user, string date)
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
}
