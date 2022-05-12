namespace Models
{
  public class JsonMessage<T>
  {
    public string type;
    public T data;

    public JsonMessage(string type, T data)
    {
      this.type = type;
      this.data = data;
    }
  }
}
