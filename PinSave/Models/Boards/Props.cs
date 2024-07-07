using Newtonsoft.Json;

namespace PinSave.Models.Boards
{
    public class Props
    {
        [JsonProperty("initialReduxState")]
        public InitialReduxState? InitialReduxState { get; set; }
    }
}