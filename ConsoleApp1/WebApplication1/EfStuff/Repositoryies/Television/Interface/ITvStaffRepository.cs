using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;

namespace WebApplication1.EfStuff.Repositoryies.Television.Interface
{
    public interface ITvStaffRepository: IBaseRepository<TvStaff>
    {
        List<TvStaff> GetByChannel(string channelName);
        TvStaff GetByName(string name);
        bool HasTvAdmin();
    }
}
