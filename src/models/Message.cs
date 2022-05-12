namespace Models
{
  public class Message<T>
  {
    public string type;
    public T data;

    public Message(string type, T data)
    {
      this.type = type;
      this.data = data;
    }
  }
}
