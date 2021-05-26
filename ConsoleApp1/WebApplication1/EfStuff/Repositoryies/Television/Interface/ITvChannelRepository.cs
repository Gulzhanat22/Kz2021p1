using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;

namespace WebApplication1.EfStuff.Repositoryies.Television.Interface
{
    public interface ITvChannelRepository : IBaseRepository<TvChannel>
    {
        TvChannel GetByName(string channelName);
        bool CheckIfNameExists(string channelName);
        bool HasAny();
    }
}
