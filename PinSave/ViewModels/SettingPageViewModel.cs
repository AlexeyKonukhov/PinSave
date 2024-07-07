using CommunityToolkit.Mvvm.ComponentModel;
using PinSave.Models.AuxiliaryСlasses;

namespace PinSave.ViewModels;

public partial class SettingPageViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isDarkTheme = new GetSetSettingsApp().isDark;
    [ObservableProperty] private bool _isVariableSections = new GetSetSettingsApp().isVariable;
    private static string VariableSectionsHeader => "Разные папки";
    private static string VariableSectionsHint => "использовать разные папки для разных типов пинов";

    private static string DarkThemeHeader => "Тёмная тема";
    private static string DarkThemeHint => "использовать тёмную тему приложения";
}