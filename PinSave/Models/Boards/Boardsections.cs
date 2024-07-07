using Newtonsoft.Json;
using PinSave.Models.Contents;
using System.Collections.Generic;

namespace PinSave.Models.Boards
{
    public class Boardsections
    {
        [JsonProperty("slug")]
        public string? Slug { get; set; }

        [JsonProperty("pin_count")]
        public int? PinCount { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("preview_pins")]
        public List<PreviewPins>? PreviewPins { get; set; }
    }
}