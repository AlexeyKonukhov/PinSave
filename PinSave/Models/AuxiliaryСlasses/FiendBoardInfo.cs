using HtmlAgilityPack;
using Newtonsoft.Json;
using PinSave.Models.Boards;
using System.Threading.Tasks;

namespace PinSave.Models.AuxiliaryСlasses;

public class FiendBoardInfo(string url)
{
    public async Task<SectionsBoard?> Board()
    {
        using HttpManager manager = new();
        var html = await manager.GetPageAsync(url);
        if (html == string.Empty) return null;
        HtmlDocument doc = new();
        doc.LoadHtml(html);
        var nodes = doc.DocumentNode.SelectNodes("//*[@id=\"__PWS_INITIAL_PROPS__\"]");
        var root = JsonConvert.DeserializeObject<SectionsBoard>(nodes[0].InnerText)!;
        return root;
    }
}