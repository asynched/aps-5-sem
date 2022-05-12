using System.Text.Json;
using System.Text.Json.Serialization;


namespace Models
{
  public class Registration : Serializable
  {
    [JsonPropertyName("username")]
    public string Username { get; set; }

    public Registration(string username) : base()
    {
      this.Username = username;
    }

    public string ToJson()
    {
      return JsonSerializer.Serialize(this);
    }
  }

  public class RegistrationMessage : JsonMessage<Registration>
  {
    public static RegistrationMessage FromUsername(string username)
    {
      return new RegistrationMessage(new Registration(username));
    }
    public RegistrationMessage(Registration data) : base("REGISTRATION", data) { }


  }
}
