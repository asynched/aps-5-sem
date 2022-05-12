namespace Models
{
  public class Client
  {
    public string id;
    public string name;

    public Client(string id, string name)
    {
      this.id = id;
      this.name = name;
    }
  }

  public class ConnectedClients
  {
    public static List<Client> clients = new List<Client>();
  }

  public class ConnectedClientsMessage : Message<ConnectedClients>
  {
    public ConnectedClientsMessage(ConnectedClients data) : base("CONNECTED_CLIENTS", data) { }
  }
}