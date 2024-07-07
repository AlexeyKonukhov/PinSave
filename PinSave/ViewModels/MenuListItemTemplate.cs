using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace PinSave.ViewModels;

public class MenuListItemTemplate
{
    public MenuListItemTemplate(ViewModelBase viewModelBase, string label, string iconKey)
    {
        Label = label;
        ViewModelBase = viewModelBase;
        Application.Current!.TryFindResource(iconKey, out var res);
        Icon = (StreamGeometry)res!;
    }

    public string Label { get; }
    public StreamGeometry Icon { get; }

    public ViewModelBase ViewModelBase { get; }
}