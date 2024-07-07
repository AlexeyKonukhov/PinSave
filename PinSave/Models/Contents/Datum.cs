using Newtonsoft.Json;

namespace PinSave.Models.Contents
{
    public class Datum
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("grid_title")]
        public string? GridTitle { get; set; }

        [JsonProperty("images")]
        public Images? Images { get; set; }

        [JsonProperty("embed")]
        public Embed? Embed { get; set; }

        [JsonProperty("videos")]
        public Videos? Videos { get; set; }

        [JsonProperty("dominant_color")]
        public string? DominantColor { get; set; }

        [JsonProperty("story_pin_data")]
        public StoryPinData? StoryPinData { get; set; }
    }
}
