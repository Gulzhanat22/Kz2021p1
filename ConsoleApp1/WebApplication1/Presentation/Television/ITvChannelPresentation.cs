using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Television;

namespace WebApplication1.Presentation.Television
{
    public interface ITvChannelPresentation
    {
        List<TvChannelViewModel> GetIndexViewModel();
        TvChannelViewModel ProfileViewModel(string channelName);
        bool NameExist(string name);
        void Save(TvChannelViewModel viewModel);
        List<FullProfileViewModel> AreNotTvStaff();
        TvStaffViewModel NewDirectorViewModel(string channelName);
        void SaveDirector(TvStaffViewModel viewModel);
    }
}
