namespace Models
{
  public class Disconnection
  {
    public string id;
    public string message;
    public string user;
    public string date;

    public Disconnection(string id, string message, string user, string date)
    {
      this.id = id;
      this.message = message;
      this.user = user;
      this.date = date;
    }
  }
}
