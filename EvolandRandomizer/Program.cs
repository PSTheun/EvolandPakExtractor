using Newtonsoft.Json.Linq;

namespace EvolandRandomizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Loading cdc");
            var cdc = ReadCDC();
            Console.WriteLine("Loaded cdc");
            var chests = cdc.SelectTokens("$..actives[?(@.type == 'Chest')]");
            var songs = cdc.SelectTokens("$..actives[?(@.type == 'Song')]");

            int i = 1;
            foreach (var chest in chests)
            {
                Console.WriteLine($"Found chest: {i}/{chests.Count()}. It's path: {chest.Path}. It contains: {chest.SelectToken("value")}");
                i++;
            }
            i = 1;
            foreach (var song in songs)
            {
                Console.WriteLine($"Found chest: {i}/{songs.Count()}. It's path: {song.Path}");
                i++;
            }
            
        }

        private static JObject ReadCDC()
        {
            return JObject.Parse(File.ReadAllText("D:\\Debugging\\Projects\\Evoland Legendary Edition\\Extracted\\evo2\\data.cdb"));
        }

        private static string GetParents(JToken chest)
        {
            return string.Empty;
            
        }
    }
}