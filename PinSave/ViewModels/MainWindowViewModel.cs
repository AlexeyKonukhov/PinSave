using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PinSave.Models.AuxiliaryСlasses;
using System.Collections.ObjectModel;

namespace PinSave.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<MenuListItemTemplate> Items { get; } =
    [
        new MenuListItemTemplate(HomePageViewModel, "Меню", "Home"),
        new MenuListItemTemplate(SettingPageViewModel, "Настройки", "Settings")
    ];

    #region RelayCommand

    [RelayCommand]
    private void TriggerPaneCommand()
    {
        IsPaneOpen = !IsPaneOpen;
    }

    #endregion

    partial void OnSelectedListItemChanged(MenuListItemTemplate? value)
    {
        if (value is null) return;
        CurrentPage = value.ViewModelBase;
    }

    #region ObservableProperty

    [ObservableProperty] private MenuListItemTemplate? _selectedListItem;

    [ObservableProperty] private ViewModelBase? _currentPage = HomePageViewModel;

    [ObservableProperty] private bool _isPaneOpen;

    #endregion

    #region List Views

    private static readonly HomePageViewModel HomePageViewModel = new();
    private static readonly SettingPageViewModel SettingPageViewModel = new();

    #endregion

    public MainWindowViewModel()
    {
        Application.Current!.RequestedThemeVariant = new GetSetSettingsApp().GetTheme();
    }
}