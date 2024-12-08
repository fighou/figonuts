namespace Figounuts.Models
{
    public class PresentationModel
    {
        public Dictionary<string, string> Content { get; set; }
        public Dictionary<string, string> Images { get; set; }
        public NosFruitsSecsModel NosFruitsSecsModel { get; set; }

        public string GetContent(string key)
        {
            return Content.ContainsKey(key) ? Content[key] : $"{{{key}}}";
        }
    }
}
