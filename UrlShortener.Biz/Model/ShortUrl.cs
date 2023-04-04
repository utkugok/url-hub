using Microsoft.AspNetCore.WebUtilities;

namespace UrlShortener.Biz.Model
{
    public class ShortUrl
    {
        public int Id { get; set; }

        public string InputUrl { get; set; }

        public string NewUrl => Origin + Path;

        public string Origin { get; set; }

        public string? CustomPath { get; set; }

        public string Path
        {
            set
            {
                CustomPath = value;
            }
            get
            {
                return String.IsNullOrEmpty(CustomPath) ? WebEncoders.Base64UrlEncode(BitConverter.GetBytes(Id)) : CustomPath;
            }
        }
    }
}
