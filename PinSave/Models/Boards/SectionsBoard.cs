using Newtonsoft.Json;

namespace PinSave.Models.Boards
{
    public class SectionsBoard
    {
        [JsonProperty("initialReduxState")]
        public InitialReduxState? InitialReduxState { get; set; }
    }
}
