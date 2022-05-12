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

  public class RegistrationMessage : Message<Registration>
  {
    public RegistrationMessage(Registration data) : base("REGISTRATION", data) { }
  }
}
