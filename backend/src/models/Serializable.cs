using System.Text.Json;

namespace Models
{
  public interface Serializable
  {
    string ToJson();
  }
}
