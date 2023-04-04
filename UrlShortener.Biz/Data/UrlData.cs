using UrlShortener.Biz.AppService.ShortedUrlsService;
using UrlShortener.Biz.AppService.ShortUrlService;
using UrlShortener.Biz.Model;

namespace UrlShortener.Biz.Data;

public static class UrlData
{
    private static Random _random = new Random();
    public static List<ShortUrl> ShortUrlDTOList = new List<ShortUrl>();

    public static ShortUrl AddList(ShortUrlDTO shortUrlDTO)
    {
        var newShortedUrl = new ShortUrl()
        {
            Id = _random.Next(1, Int32.MaxValue),
            InputUrl = shortUrlDTO.url,
            Origin = GenerateOrigin(shortUrlDTO.url),
            CustomPath = shortUrlDTO.customPath
        };

        ShortUrlDTOList.Add(newShortedUrl);

        return newShortedUrl;
    }

    public static List<ShortedUrl> GetUrls()
    {
        List<ShortedUrl> shortedUrls = new List<ShortedUrl>();

        foreach (var item in ShortUrlDTOList)
        {
            var t = new ShortedUrl()
            {
                Url = item.InputUrl,
                UrlId = item.Id,
                NewUrl = item.NewUrl
            };
            shortedUrls.Add(t);
        }

        return shortedUrls;
    }

    internal static ShortedUrl GetUrl(int id)
    {
        var t = ShortUrlDTOList.Single(q => q.Id == id);

        return new ShortedUrl()
        {
            Url = t.InputUrl,
            UrlId = t.Id
        };
    }

    internal static string? GetUrl(string url)
    {
        var redirectedUrl = ShortUrlDTOList?.FirstOrDefault(q => q.NewUrl == url);

        return redirectedUrl is not null ? redirectedUrl.InputUrl : "";
    }

    private static string GenerateOrigin(string url)
    {
        string[] strings = url.Split("/");

        string response = "";

        for (int i = 0; i < strings.Length; i++)
        {
            if (strings[i] is "https:")
            {
                strings[i] = "http:";
            }
            else if (strings[i].Contains(':'))
            {
                return response += strings[i] + "/";
            }
            if (strings[i].Contains("www."))
            {
                strings[i] = strings[i].Replace("www.", string.Empty);
            }
            if (strings[i].Contains(".com"))
            {
                strings[i] = strings[i].Replace(".com", string.Empty);
            }
            if (strings[i].Contains('-'))
            {
                strings[i] = strings[i].Replace('-', '.');
            }
            if (strings[i] is ".com")
            {
                strings[i] = string.Empty;
                return response += strings[i] + "/";
            }
            if (response.Contains("//") && strings[i].Contains('.'))
            {
                return response += strings[i] + "/";
            }

            response += strings[i] + "/";

        }

        return response;
    }
}