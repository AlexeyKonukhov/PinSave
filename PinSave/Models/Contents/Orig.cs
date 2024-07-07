﻿using Newtonsoft.Json;

namespace PinSave.Models.Contents
{
    public class Orig
    {
        [JsonProperty("width")]
        public int? Width { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}