using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;

namespace WebApplication1.EfStuff.Repositoryies.Television.Interface
{
    public interface ITvProgrammeRepository : IBaseRepository<TvProgramme>
    {
        List<TvProgramme> GetByChannel(string channelName);
        TvProgramme GetByName(string programmeName);
        bool CheckIfNameExists(string programmeName);
        bool CheckIfNameExistsForEdit(string programmeName, long id);
    }
}
