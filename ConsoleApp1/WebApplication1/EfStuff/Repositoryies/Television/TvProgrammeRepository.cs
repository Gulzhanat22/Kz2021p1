using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;
using WebApplication1.EfStuff.Repositoryies.Television.Interface;

namespace WebApplication1.EfStuff.Repositoryies.Television
{
    public class TvProgrammeRepository : BaseRepository<TvProgramme>, ITvProgrammeRepository
    {
        public TvProgrammeRepository(KzDbContext kzDbContext) : base(kzDbContext)
        {
        }

        public List<TvProgramme> GetByChannel(string channelName)
        {
            return _dbSet.Where(x => x.Channel.Name == channelName).ToList();
        }

        public TvProgramme GetByName(string programmeName)
        {
            return _dbSet.SingleOrDefault(x => x.Name == programmeName);
        }

        public bool CheckIfNameExists(string programmeName)
        {
            return _dbSet.Any(x => x.Name == programmeName);
        }

        public bool CheckIfNameExistsForEdit(string programmeName, long id)
        {
            return _dbSet.Any(x => x.Name == programmeName && x.Id != id);
        }
    }
}
