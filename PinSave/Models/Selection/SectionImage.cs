using HtmlAgilityPack;
using Newtonsoft.Json;
using PinSave.Models.AuxiliaryСlasses;
using PinSave.Models.Contents;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinSave.Models.Selection;

public class SectionImage(TemplateSections template, string url, string bookmark)
{
    public async Task<List<ContentModel>?> ImageUrls()
    {
        if (template.Id is "" or null)
            return null;
        var address = "https://ru.pinterest.com/resource/BoardSectionPinsResource/get/?source_url=" +
                      url.Remove(0, 24) + template.Caption +
                      "/&data={\"options\":{\"currentFilter\":-1,\"field_set_key\":\"react_grid_pin\",\"is_own_profile_pins\":true,\"page_size\":250,\"redux_normalize_feed\":true,\"section_id\":\"" +
                      template.Id + "\",\"orbac_subject_id\":\"\", \"bookmarks\": [\"" + bookmark +
                      "\"]},\"context\":{}}";
        using HttpManager manager = new();
        var html = await manager.GetPageAsync(address);
        if (html == string.Empty) return null;
        HtmlDocument doc = new();
        doc.LoadHtml(html);
        var root = JsonConvert.DeserializeObject<Root>(doc.Text);
        if (root is not null)
        {
            if (root.ResourceResponse!.Data!.Count == 0) return null!;
            var datum = root.ResourceResponse.Data;

            List<ContentModel> contentModels = [];
            contentModels.AddRange(datum.Select(t => new ContentModel(t.Embed!, t.Images!, t.Videos!, t.StoryPinData!,
                root.ResourceResponse.Bookmark!, t.DominantColor!, t.GridTitle!)));
            contentModels = contentModels.Where(cm => cm.Images is not null).Distinct().ToList();
            return contentModels;
        }

        return null!;
    }
}