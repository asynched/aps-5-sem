namespace Utils
{
  public class Strings
  {
    private static T Random<T>(T[] source)
    {
      var random = new Random();
      return source[random.Next(0, source.Length)];
    }
    public static string RandomName(int length = 8)
    {
      var random = new Random();
      var syllables = "aeiou".ToCharArray();
      var consonants = "bcdfghjklmnpqrstvwxyz".ToCharArray();

      var name = "";

      for (var i = 0; i < length; i++)
      {
        if (i % 2 == 0)
        {
          name += Random(consonants);
        }
        else
        {
          name += Random(syllables);
        }
      }

      return name;
    }
  }
}