using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;
using WebApplication1.EfStuff.Repositoryies.Television.Interface;

namespace WebApplication1.EfStuff.Repositoryies.Television
{
    public class TvChannelRepository : BaseRepository<TvChannel>, ITvChannelRepository
    {
        public TvChannelRepository(KzDbContext kzDbContext) : base(kzDbContext)
        {
        }
        public TvChannel GetByName(string channelName)
        {
            return _dbSet.SingleOrDefault(x => x.Name == channelName);
        }

        public bool CheckIfNameExists(string channelName)
        {
            return _dbSet.Any(x => x.Name == channelName);
        }

        public bool HasAny()
        {
            return _dbSet.Any();
        }
    }
}
