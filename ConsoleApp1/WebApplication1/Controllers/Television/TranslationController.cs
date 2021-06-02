using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Television;
using WebApplication1.Presentation.Television;

namespace WebApplication1.Controllers.Television
{
    public class TranslationController : Controller
    {
        private ITranslationPresentation _translationPresentation { get; set; }
        public TranslationController(ITranslationPresentation translationPresentation)
        {
            _translationPresentation = translationPresentation;
        }

        public IActionResult Index()
        {
            var viewModels = _translationPresentation.TranslationIndex();
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TranslationViewModel viewModel)
        {
            _translationPresentation.Save(viewModel);
            return View();
        }

        public IActionResult AddToSchedule(long id)
        {
            var viewModel = _translationPresentation.Find(id);
            _translationPresentation.SaveSchedule(viewModel);
            return View();
        }
    }
}
