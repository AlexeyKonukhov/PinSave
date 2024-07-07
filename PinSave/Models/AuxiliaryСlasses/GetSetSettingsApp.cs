using Avalonia;
using Avalonia.Styling;
using Newtonsoft.Json;
using System;
using System.IO;

namespace PinSave.Models.AuxiliaryСlasses
{
    public class GetSetSettingsApp
    {
         readonly string settingsPath = AppContext.BaseDirectory + "settings.json";
         Settings? appSettings;

        public GetSetSettingsApp()
        {
           
            appSettings = JsonConvert.DeserializeObject<Settings>(GetSettings());
        }

        public  ThemeVariant GetTheme()
        {

            if (appSettings!.DarkTheme)
                return ThemeVariant.Dark;
            else
                return ThemeVariant.Light;
        }

        public  bool isDark
        {
            get
            {
                if (appSettings!.DarkTheme)
                    return true;
                else
                    return false;
            }
            private set { }
        }

        public  bool isVariable
        {
            get
            {

                if (appSettings!.VariableFolder)
                    return true;
                else
                    return false;
            }
            private set { }
        }

        public  bool GetVariableFolder()
        {
            return appSettings!.VariableFolder;
        }

        public  void SetTheme(bool theme)
        {
            if (appSettings is not null)
            {
                appSettings.DarkTheme = theme;
                SaveSettings(JsonConvert.SerializeObject(appSettings));
                appSettings = JsonConvert.DeserializeObject<Settings>(GetSettings());
                Application.Current!.RequestedThemeVariant = GetTheme();
            }
        }

        public  void SetVariableFolder(bool variable)
        {
            if (appSettings is not null)
            {
                appSettings.VariableFolder = variable;
                SaveSettings(JsonConvert.SerializeObject(appSettings));
                appSettings = JsonConvert.DeserializeObject<Settings>(GetSettings());
            }
        }

        public  void SaveSettings(string newSettings)
        {
            using StreamWriter streamWriter = new(settingsPath);
            streamWriter.Write(newSettings);
        }

        string GetSettings()
        {
            using StreamReader streamReader = new(settingsPath);
            return streamReader.ReadToEnd();
        }
    }
}
