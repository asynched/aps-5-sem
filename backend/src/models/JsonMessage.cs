using System.Text.Json;
using System.Text.Json.Serialization;


namespace Models
{
  public class JsonMessage<T> : Serializable
  {
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("data")]
    public T Data { get; set; }

    public JsonMessage(string type, T data)
    {
      this.Type = type;
      this.Data = data;
    }

    public string ToJson()
    {
      return JsonSerializer.Serialize(this);
    }
  }
}
