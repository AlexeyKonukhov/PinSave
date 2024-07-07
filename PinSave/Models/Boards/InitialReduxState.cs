using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinSave.Models.Boards
{
    public class InitialReduxState
    {
        [JsonProperty("boards")]
        public Dictionary<string, Boards>? Boards { get; set; }

        [JsonProperty("boardsections")]
        public Dictionary<string, Boardsections>? Boardsections { get; set; }
    }
}