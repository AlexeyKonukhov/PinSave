using Newtonsoft.Json;

namespace PinSave.Models.Contents
{
    public class Images
    {
        [JsonProperty("orig")]
        public Orig? Orig { get; set; }
        [JsonProperty("170x")]
        public _170x? _170X { get; set; }
    }
}