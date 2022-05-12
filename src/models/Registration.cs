namespace Models
{
  public class Registration
  {
    public string username;

    public Registration(string username) : base()
    {
      this.username = username;
    }
  }

  public class RegistrationMessage : JsonMessage<Registration>
  {
    public RegistrationMessage(Registration data) : base("REGISTRATION", data) { }
  }
}
