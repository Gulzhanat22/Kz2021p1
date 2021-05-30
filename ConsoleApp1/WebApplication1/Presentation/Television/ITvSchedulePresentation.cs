using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;
using WebApplication1.Models.Television;

namespace WebApplication1.Presentation.Television
{
    public interface ITvSchedulePresentation
    {
        List<TvScheduleViewModel> GetIndexViewModel(string channelName, string date);
        List<TvProgrammeShortViewModel> GetProgrammesViewModel();
        void Save(TvScheduleViewModel viewModel);
        TvScheduleViewModel Find(long id);
        void Edit(TvScheduleViewModel viewModel);
        bool Delete(long id);
        bool TimeIsValid(TvScheduleViewModel viewModel);
        TvSchedule ConvertToModel(TvScheduleViewModel viewModel);
    }
}
