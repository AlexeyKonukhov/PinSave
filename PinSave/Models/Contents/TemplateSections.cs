using CommunityToolkit.Mvvm.ComponentModel;
using PinSave.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PinSave.Models.Contents;

public partial class TemplateSections(
    string url,
    string caption,
    string count,
    string id,
    List<ContentModel> contentModels) : ViewModelBase
{
    [ObservableProperty] private bool _allCheck;

    public string? Img { get; } = url;
    public string? Caption { get; } = caption;
    public string? Count { get; } = count;
    public string? Id { get; } = id;
    public List<ContentModel>? ContentModels { get; set; } = contentModels;

    public void IsCheckSectionPins()
    {
        if (ContentModels is null) return;
        for (var i = 0; i < ContentModels.Count; i++) ContentModels.ElementAt(i).Checked = false;
    }
}