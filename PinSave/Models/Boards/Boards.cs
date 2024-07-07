using Newtonsoft.Json;

namespace PinSave.Models.Boards
{
    public class Boards
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("pin_count")]
        public int? PinCount { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("image_cover_hd_url")]
        public string? ImageCoverHdUrl { get; set; }
    }
}