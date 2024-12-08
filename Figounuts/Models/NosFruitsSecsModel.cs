namespace Figounuts.Models
{
    public class FruitImage
    {
        public string ImagePath { get; set; }
        public string Text { get; set; }
    }

    public class NosFruitsSecsModel
    {
        public string MainImage { get; set; }
        public List<FruitImage> FruitImages { get; set; }
    }

}
