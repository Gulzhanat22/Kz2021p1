using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Television;

namespace WebApplication1.Presentation.Television
{
    public interface ITvStaffPresentation
    {
        List<TvStaffViewModel> GetIndexViewModelByChannel(string channelName);
        TvStaffViewModel GetProfileViewModel();
        List<FullProfileViewModel> AreNotTvStaff();
        void Save(TvStaffViewModel viewModel);
        List<TvStaffViewModel> GetStaffByChannel();
        TvProgrammeStaffViewModel PutStaffToProgramme(long id);
        void SavePutStaffToProgramme(TvProgrammeStaffViewModel viewModel);
        List<TvProgrammeStaffViewModel> GetStaffByProgramme(string programmeName);
        List<TvProgrammeStaffViewModel> GetProgrammeByStaff(string name);
    }
}
