using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinSave.Models.Contents
{
    public class StoryPinData
    {
        [JsonProperty("pages_preview")]
        public List<PagesPreview>? PagesPreview { get; set; }
    }
}