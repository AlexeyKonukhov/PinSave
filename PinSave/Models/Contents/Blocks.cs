using Newtonsoft.Json;

namespace PinSave.Models.Contents
{
    public class Blocks
    {
        [JsonProperty("video")]
        public Videos? Video { get; set; }
    }
}