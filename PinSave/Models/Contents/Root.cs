using Newtonsoft.Json;

namespace PinSave.Models.Contents
{
    public class Root
    {
        [JsonProperty("resource_response")]
        public ResourceResponse? ResourceResponse { get; set; }
    }
}