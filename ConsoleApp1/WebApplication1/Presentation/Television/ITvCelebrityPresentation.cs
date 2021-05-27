using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Television;

namespace WebApplication1.Presentation.Television
{
    public interface ITvCelebrityPresentation
    {
        List<TvCelebrityViewModel> GetIndexViewModel();
        List<FullProfileViewModel> AreNotCelebrity();
        void Save(TvCelebrityViewModel viewModel);
        TvProgrammeCelebrityViewModel PutCelebrityToProgramme(long id);
        void SavePutCelebrityToProgramme(TvProgrammeCelebrityViewModel viewModel);
        List<TvProgrammeCelebrityViewModel> GetCelebrityByProgramme(string programmeName);
        List<TvProgrammeShortViewModel> GetTvProgrammesOfChannel();
        void SaveNews(CelebrityNewsViewModel viewModel);
    }
}
