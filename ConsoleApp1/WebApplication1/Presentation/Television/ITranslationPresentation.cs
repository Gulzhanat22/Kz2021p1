using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Television;

namespace WebApplication1.Presentation.Television
{
    public interface ITranslationPresentation
    {
        List<TranslationViewModel> TranslationIndex();
        void Save(TranslationViewModel viewModel);
        TranslationViewModel Find(long id);
        void SaveSchedule(TranslationViewModel viewModel);
    }
}
