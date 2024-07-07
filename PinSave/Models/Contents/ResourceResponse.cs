using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinSave.Models.Contents
{
    public class ResourceResponse
    {
        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("endpoint_name")]
        public string? EndpointName { get; set; }

        [JsonProperty("data")]
        public List<Datum>? Data { get; set; }

        [JsonProperty("bookmark")]
        public string? Bookmark { get; set; }

        [JsonProperty("http_status")]
        public int? HttpStatus { get; set; }
    }
}