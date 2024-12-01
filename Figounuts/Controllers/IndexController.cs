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
                { "Home", _localizer["Home"] },
                { "Presentation", _localizer["Presentation"] },
                { "Contact", _localizer["Contact"] },
                { "ProjectTitle", _localizer["ProjectPresentationTitle"] },
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
                { "Leader", _localizer["Leader"] },
                { "CompanyName", _localizer["CompanyName"] },
                { "PromoterName", _localizer["PromoterName"] },
                { "Address", _localizer["Address"] },
                { "Email", _localizer["Email"] },
                { "PhoneNumber", _localizer["PhoneNumber"] },
                { "ContactUs", _localizer["ContactUs"] },
                { "Name", _localizer["Name"] },
                { "Phone", _localizer["Phone"] },
                { "Message", _localizer["Message"] },
                { "SendButton", _localizer["SendButton"] }
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

        [HttpPost]
        public IActionResult SendContact(string Name, string Phone, string Message)
        {
            // Send the contact message, save it, or send via email (depending on your logic)
            TempData["SuccessMessage"] = "Votre message a été envoyé avec succès!";
            return RedirectToAction("Index");
        }
    }
}
