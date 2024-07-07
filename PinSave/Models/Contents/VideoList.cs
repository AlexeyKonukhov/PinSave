using Newtonsoft.Json;

namespace PinSave.Models.Contents
{
    public class VideoList
    {
        [JsonProperty("V_HLSV4")]
        public VHLSV4? VHLSV4 { get; set; }

        [JsonProperty("V_720P")]
        public V720P? V720P { get; set; }

        [JsonProperty("V_HLSV3_WEB")]
        public VHLSV3WEB? VHLSV3WEB { get; set; }

        [JsonProperty("V_HLSV3_MOBILE")]
        public VHLSV3MOBILE? VHLSV3MOBILE { get; set; }
    }
}