using Newtonsoft.Json;

namespace PinSave.Models.Contents
{
    public class PreviewPins
    {
        [JsonProperty("image_square_url")]
        public string? ImageSquareUrl { get; set; }
    }
}