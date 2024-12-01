using Figounuts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

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
            if (!string.IsNullOrEmpty(lang))
            {
                var culture = new System.Globalization.CultureInfo(lang);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            var content = new Dictionary<string, string>
        {
            { "ProjectTitle", _localizer["ProjectPresentationTitle"] },
            { "ProjectDescription", _localizer["ProjectPresentationText"] },
            { "VisionTitle", _localizer["VisionTitle"] },
            { "VisionDescription", _localizer["VisionText"] },
            { "ValuesTitle", _localizer["ValuesTitle"] },
            { "ValuesDescription", _localizer["ValuesText"] },
            { "MissionTitle", _localizer["MissionTitle"] },
            { "MissionDescription", _localizer["MissionText"] },
            { "QualityTitle", _localizer["QualityCommitmentTitle"] },
            { "QualityDescription", _localizer["QualityCommitmentText"] },
            { "EducationTitle", _localizer["EducationTitle"] },
            { "EducationDescription", _localizer["EducationText"] },
            { "SustainabilityTitle", _localizer["SustainabilityTitle"] },
            { "SustainabilityDescription", _localizer["SustainabilityText"] },
            { "CommunityTitle", _localizer["CommunityTitle"] },
            { "CommunityDescription", _localizer["CommunityText"] },
            { "Welcome", _localizer["Welcome"] },
            { "Leader", _localizer["Leader"] }
        };

            var images = new Dictionary<string, string>
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

            var model = new PresentationModel
            {
                Content = content,
                Images = images
            };

            return View(model);
        }
    }
}
