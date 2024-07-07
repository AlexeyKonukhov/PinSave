using CommunityToolkit.Mvvm.ComponentModel;
using PinSave.Models.AuxiliaryСlasses;
using PinSave.ViewModels;

namespace PinSave.Models.Contents;

public partial class ContentModel : ViewModelBase
{
    [ObservableProperty] private bool _checked;

    public ContentModel(Embed? embed, Images? images, Videos? videos, StoryPinData? storyPinData, string? bookMark,
        string? dominantColor, string? gridTitle)
    {
        Embed = embed;
        Images = images;
        if (videos is not null && videos.VideoList!.VHLSV3MOBILE!.Url!.Contains(".m3u8"))
            Url = videos.VideoList!.VHLSV3MOBILE.Url!.Replace("iht", "mc").Replace("hls", "720p")
                .Replace(".m3u8", ".mp4");
        Videos = videos;
        if (storyPinData?.PagesPreview?[0].Blocks?[0].Video != null)
            Url = storyPinData.PagesPreview?[0].Blocks?[0]!.Video!.VideoList!.VHLSV3MOBILE!.Url!.Replace("iht", "mc")
                .Replace("hls", "720p").Replace(".m3u8", ".mp4");


        StoryPinData = storyPinData;
        BookMark = bookMark;
        DominantColor = dominantColor;
        GridTitle = gridTitle;
    }

    public Embed? Embed { get; private set; }
    public Images? Images { get; }
    public Videos? Videos { get; }
    public StoryPinData? StoryPinData { get; }
    public string? BookMark { get; private set; }
    public string? DominantColor { get; private set; }
    public string? GridTitle { get; private set; }

    public TypeContent? Type
    {
        get
        {
            if (Videos is not null)
                return TypeContent.Vid;
            
            if (Images!.Orig!.Url!.Contains(".gif"))
                return TypeContent.Gif;
            return StoryPinData?.PagesPreview?[0].Blocks?[0].Video is not null ? TypeContent.Vid : TypeContent.Img;
        }
    }

    public string? Url { get; private set; } = "";
}