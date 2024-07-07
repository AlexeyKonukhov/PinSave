using Newtonsoft.Json;

namespace PinSave.Models.Contents
{
    public class Videos
    {
        [JsonProperty("video_list")]
        public VideoList? VideoList { get; set; }
    }
}