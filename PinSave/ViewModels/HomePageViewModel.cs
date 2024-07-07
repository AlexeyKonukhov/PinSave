using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PinSave.Models.AuxiliaryСlasses;
using PinSave.Models.Contents;
using PinSave.Models.Selection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PinSave.ViewModels;

public partial class HomePageViewModel : ViewModelBase
{
    public string? LinkBoard { get; set; }

    #region Property

    [ObservableProperty] private double _progressBarValue;

    [ObservableProperty] private bool _progressBarVisible;


    [ObservableProperty] private bool _preloaderVisible;


    [ObservableProperty] private bool _isVisibleAll;


    [ObservableProperty] private ObservableCollection<ContentModel>? _noSection = [];

    [ObservableProperty] private ObservableCollection<TemplateSections>? _boardSections = [];

    [ObservableProperty] private TemplateSections? _selectedListItem;

    [ObservableProperty] private TemplateSections? _tempListItems;


    [ObservableProperty] private List<ContentModel>? _downloadList = [];

    partial void OnSelectedListItemChanging(TemplateSections? value)
    {
        if (value is null)
            return;
        TempListItems = value;
    }

    #endregion

    #region Command

    [RelayCommand]
    private async Task GetPins()
    {
        if (Uri.IsWellFormedUriString(LinkBoard, UriKind.Absolute))
        {
            PreloaderVisible = true;
            Clearing();
            FiendBoardInfo fiendBoardInfo = new(LinkBoard!);
            var sectionsBoard = await fiendBoardInfo.Board();
            if (sectionsBoard!.InitialReduxState == null)
            {
                PreloaderVisible = false;
                return;
            } 
            if (sectionsBoard.InitialReduxState!.Boards!.Count <= 0)
            {
                PreloaderVisible = false;
                return;
            }

            var bookmark = "";
            var boardId = sectionsBoard.InitialReduxState!.Boards!.Values.First().Id!;
            var section = sectionsBoard.InitialReduxState!.Boardsections!;

            while (bookmark is not null)
            {
                var image = await new BoardImage(boardId, LinkBoard!, bookmark).DownImg();
                if (image is not null)
                {
                    for (var i = 0; i < image.Count; i++) NoSection!.Add(image[i]);

                    bookmark = image.First().BookMark!;
                }
                else
                {
                    bookmark = null;
                }
            }

            if (section is not null)
            {
                if (section.Count != 0)
                    for (var i = 0; i < section.Count; i++)
                    {
                        List<ContentModel> contentModels = [];
                        bookmark = "";
                        BoardSections!.Add(new TemplateSections(
                            section.Values.ElementAt(i).PreviewPins!.First().ImageSquareUrl!,
                            section.Values.ElementAt(i).Slug!,
                            section.Values.ElementAt(i).PinCount!.ToString()!,
                            section.Values.ElementAt(i).Id!, contentModels));
                        while (bookmark is not null)
                        {
                            var image = await new SectionImage(BoardSections.ElementAt(i), LinkBoard!, bookmark)
                                .ImageUrls();
                            if (image is not null)
                            {
                                contentModels.AddRange(image);

                                bookmark = image.First().BookMark!;
                            }
                            else
                            {
                                bookmark = null;
                            }
                        }
                        if (contentModels.Count != 0)
                            BoardSections!.ElementAt(i).ContentModels = contentModels;
                    }
            }
            if (NoSection is not null)
                BoardSections!.Add(new TemplateSections(NoSection!.First().Images!._170X!.Url!, "Без секции",
                    NoSection!.Count.ToString(), "", [.. NoSection]));
            SelectedListItem = BoardSections!.First();
            if (TempListItems is not null) IsVisibleAll = true;
            PreloaderVisible = false;
        }
    }

    [RelayCommand]
    private void CheckAllPinsInSection()
    {
        for (var i = 0; i < TempListItems!.ContentModels!.Count; i++)
            TempListItems.ContentModels.ElementAt(i).Checked = TempListItems!.AllCheck;
        var index = BoardSections!.IndexOf(TempListItems!);
        if (index > 0)
            BoardSections![index] = TempListItems!;
    }

    private string[] GetPath(IStorageItem? t)
    {
        if (new GetSetSettingsApp().GetVariableFolder())
        {
            Directory.CreateDirectory(t!.Path.LocalPath.Replace(t.Path.Segments[^1], "Img"));
            Directory.CreateDirectory(t.Path.LocalPath.Replace(t.Path.Segments[^1], "Vid"));
            Directory.CreateDirectory(t.Path.LocalPath.Replace(t.Path.Segments[^1], "Gif"));
            return [$"{t.Path.LocalPath.Replace(t.Path.Segments[^1], "Img\\pin")}",
                $"{t.Path.LocalPath.Replace(t.Path.Segments[^1], "Vid\\pin")}",
                $"{t.Path.LocalPath.Replace(t.Path.Segments[^1], "Gif\\pin")}"];
        }
        return [$"{t!.Path.LocalPath.Replace(t.Path.Segments[^1], "pin")}",
            $"{t.Path.LocalPath.Replace(t.Path.Segments[^1], "pin")}",
            $"{t.Path.LocalPath.Replace(t.Path.Segments[^1], "pin")}"];
    }


    [RelayCommand]
    private async Task DownloadPins()
    {
        var t = await DoSaveFilePickerAsync();
        if (t is null)
            return;
        string[] pathFolders = GetPath(t);
        DownloadList!.Clear();
        ProgressBarValue = 0;
        IsVisibleAll = false;
        ProgressBarVisible = true;
        for (var i = 0; i < BoardSections!.Count; i++)
            for (var j = 0; j < BoardSections.ElementAt(i).ContentModels!.Count; j++)
                if (BoardSections!.ElementAt(i).ContentModels!.ElementAt(j).Checked)
                    DownloadList.Add(BoardSections!.ElementAt(i).ContentModels!.ElementAt(j));

        if (DownloadList.Count > 0)
        {
            using var client = new HttpClient();
            for (var i = 0; i < DownloadList.Count; i++)
                switch (DownloadList.ElementAt(i).Type)
                {
                    case TypeContent.Img:
                        {
                            var tempImg = DownloadList!.ElementAt(i).Images!.Orig!.Url!;
                            await SavePins(pathFolders[0], i, client, new Uri(tempImg));
                            break;
                        }
                    case TypeContent.Vid:
                        {
                            var tempVideo = DownloadList.ElementAt(i).Url!;
                            await SavePins(pathFolders[1], i, client, new Uri(tempVideo));
                            break;
                        }
                    case TypeContent.Gif:
                        {
                            var tempImg = DownloadList!.ElementAt(i).Images!.Orig!.Url!;
                            await SavePins(pathFolders[2], i, client, new Uri(tempImg));
                            break;
                        }
                }
        }

        DownloadList!.Clear();
        TempListItems!.AllCheck = false;
        IsCheckAllSections();
        IsVisibleAll = true;
        ProgressBarVisible = false;
    }

    #endregion

    #region User Method

    private void Clearing()
    {
        SelectedListItem = null;
        BoardSections!.Clear();
        NoSection!.Clear();
        DownloadList!.Clear();
        TempListItems = null;
        ProgressBarValue = 0;
    }

    private void IsCheckAllSections()
    {
        for (var i = 0; i < BoardSections!.Count; i++) BoardSections.ElementAt(i).IsCheckSectionPins();
    }

    private async Task SavePins(string path, int i, HttpClient client, Uri url)
    {
        var stream = await client.GetStreamAsync(url);

        var file = File.Create(path!.Replace("pin", $"pin-{i}-{url.Segments[^1]}"));
        await stream.CopyToAsync(file);
        stream.Close();
        ProgressBarValue += 100.0 / DownloadList!.Count;
    }
    private static async Task<IStorageFile?> DoSaveFilePickerAsync()
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            desktop.MainWindow?.StorageProvider is not { } provider)
            throw new NullReferenceException("Missing StorageProvider instance.");

        return await provider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "PinSave",
            SuggestedFileName = "pin-name.jpg"
        });
    }

    #endregion
}