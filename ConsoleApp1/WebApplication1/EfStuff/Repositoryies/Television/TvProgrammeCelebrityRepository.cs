using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;
using WebApplication1.EfStuff.Repositoryies.Television.Interface;

namespace WebApplication1.EfStuff.Repositoryies.Television
{
    public class TvProgrammeCelebrityRepository : BaseRepository<TvProgrammeCelebrity>, ITvProgrammeCelebrityRepository
    {
        public TvProgrammeCelebrityRepository(KzDbContext kzDbContext) : base(kzDbContext)
        {
        }

        public List<TvProgrammeCelebrity> GetByProgrammeName(string programmeName)
        {
            return _dbSet.Where(x => x.Programme.Name == programmeName).ToList();
        }
    }
}
