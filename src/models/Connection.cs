namespace Models
{
  public class Connection
  {
    public string id;
    public string message;
    public string user;
    public string date;

    public Connection(string id, string message, string user, string date)
    {
      this.id = id;
      this.message = message;
      this.user = user;
      this.date = date;
    }
  }

  public class ConnectionMessage : JsonMessage<Connection>
  {
    public ConnectionMessage(Connection data) : base("CONNECTION", data) { }
  }
}
