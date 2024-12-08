using Figounuts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Figounuts.Controllers
{
    public class IndexController : Controller
    {
        private readonly IStringLocalizer<IndexController> _localizer;

        public IndexController(IStringLocalizer<IndexController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index(string lang)
        {
            SetCulture(lang);
            var model = CreatePresentationModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SendContact(string name, string phone, string message)
        {
            TempData["SuccessMessage"] = "Votre message a été envoyé avec succès!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult NosFruitsSecs()
        {
            var model = CreatePresentationModel();
            return View(model);
        }

        public IActionResult Presentation()
        {
            var model = CreatePresentationModel();
            return View(model);
        }

        public IActionResult Contact()
        {
            var model = CreatePresentationModel();
            return View(model);
        }

        private void SetCulture(string lang)
        {
            var culture = string.IsNullOrEmpty(lang) ? "fr" : lang;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        private PresentationModel CreatePresentationModel()
        {
            return new PresentationModel
            {
                Content = GetLocalizedContent(),
                Images = GetImages(),
                NosFruitsSecsModel = CreateNosFruitsSecsModel()
            };
        }

        private Dictionary<string, string> GetLocalizedContent()
        {
            var contentKeys = new[]
            {
                "Home", "Presentation", "Contact", "ProjectTitle", "VisionTitle", "VisionDescription",
                "ValuesTitle", "ValuesDescription", "MissionTitle", "MissionDescription", "QualityTitle",
                "QualityDescription", "EducationTitle", "EducationDescription", "SustainabilityTitle",
                "SustainabilityDescription", "CommunityTitle", "CommunityDescription", "Welcome", "Leader",
                "CompanyName", "PromoterName", "Address", "Email", "PhoneNumber", "ContactUs", "Name", "Phone",
                "Message", "SendButton", "NosFruitsSecs", "NosPacks", "Figounuts", "Discover", "Croquez"
            };

            return contentKeys.ToDictionary(key => key, key => _localizer[key] ?? $"{{{key}}}");
        }

        private Dictionary<string, string> GetImages()
        {
            return new Dictionary<string, string>
            {
                { "Vision", "/Images/Vision.png" },
                { "Values", "/Images/Values.png" },
                { "Mission", "/Images/Mission.png" },
                { "Quality", "/Images/Quality.png" },
                { "Education", "/Images/Education.png" },
                { "Sustainability", "/Images/Sustainability.png" },
                { "Community", "/Images/Community.png" },
                { "ProjectDescription", "/Images/ProjectDescription.png" }
            };
        }

        private NosFruitsSecsModel CreateNosFruitsSecsModel()
        {
            return new NosFruitsSecsModel
            {
                MainImage = "/Images/FigouNuts-04_1024x1024.jpg",
                FruitImages = new List<FruitImage>
                {
                    new FruitImage { ImagePath = "/Images/NosFruitsSecs/1.jpg", Text = "Amandes à partir de 40.00 dh" },
                    new FruitImage { ImagePath = "/Images/NosFruitsSecs/2.jpg", Text = "Mix Figou Nuts à partir de 46.00 dh" },
                    new FruitImage { ImagePath = "/Images/NosFruitsSecs/3.jpg", Text = "Noix de Cajou à partir de 49.00 dh" },
                    new FruitImage { ImagePath = "/Images/NosFruitsSecs/4.jpg", Text = "Pistache à partir de 49.00 dh" },
                    new FruitImage { ImagePath = "/Images/NosFruitsSecs/5.jpg", Text = "Noix de Cajou à partir de 49.00 dh" },
                    new FruitImage { ImagePath = "/Images/NosFruitsSecs/6.jpg", Text = "Pistache à partir de 49.00 dh" },
                    new FruitImage { ImagePath = "/Images/NosFruitsSecs/7.jpg", Text = "Pack gourmand à partir de 420.00 dh" },
                    new FruitImage { ImagePath = "/Images/NosFruitsSecs/8.jpg", Text = "Amandes à partir de 40.00 dh" }
                }
            };
        }
    }
}
