using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinSave.Models.Contents
{
    public class PagesPreview
    {
        [JsonProperty("blocks")]
        public List<Blocks>? Blocks { get; set; }
    }
}