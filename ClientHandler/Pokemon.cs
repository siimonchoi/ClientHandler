using System.Text.Json.Serialization;

namespace ClientHandler
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        public string ResponseHeader { get; set; }

    }
}
