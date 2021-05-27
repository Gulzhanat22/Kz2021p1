using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Television;

namespace WebApplication1.Presentation.Television
{
    public interface ITvProgrammePresentation
    {
        List<TvProgrammeViewModel> GetIndexViewModel();
        List<TvProgrammeViewModel> GetListViewModel(string channelName);
        TvProgrammeViewModel GetProfileViewModel(string programmeName);
        Task<string> UploadAvatar(IFormFile avatarFile);
        bool NameExist(string name);
        bool NameExist(string name, long id);
        Task SaveModel(TvProgrammeViewModel viewModel);
        TvProgrammeShortViewModel FindViewModel(long id);
        void Edit(TvProgrammeShortViewModel viewModel);
        bool Delete(long id);
    }
}
