using Newtonsoft.Json;

namespace PinSave.Models.Contents
{
    public class VHLSV3WEB
    {
        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("thumbnail")]
        public string? Thumbnail { get; set; }
    }
}