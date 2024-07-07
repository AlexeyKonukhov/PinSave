using Newtonsoft.Json;

namespace PinSave.Models.Contents
{
    public class Embed
    {
        [JsonProperty("src")]
        public string? Src { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}