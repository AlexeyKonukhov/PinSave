using System.Text.Json.Serialization;

namespace PinSave.Models.AuxiliaryСlasses
{
    public class Settings
    {
        [JsonPropertyName("darkTheme")]
        public bool DarkTheme { get; set; }

        [JsonPropertyName("variableFolder")]
        public bool VariableFolder { get; set; }
    }
}
