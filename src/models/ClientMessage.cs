namespace Models
{
  public class Message
  {
    public string id;
    public string message;
    public string user;
    public string date;

    public Message(string id, string message, string user, string date)
    {
      this.id = id;
      this.message = message;
      this.user = user;
      this.date = date;
    }
  }

  public class ClientMessage : JsonMessage<Message>
  {
    public ClientMessage(Message data) : base("MESSAGE", data) { }
  }
}
