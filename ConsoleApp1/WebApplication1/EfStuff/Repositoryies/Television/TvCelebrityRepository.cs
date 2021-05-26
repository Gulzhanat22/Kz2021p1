using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;
using WebApplication1.EfStuff.Repositoryies.Television.Interface;

namespace WebApplication1.EfStuff.Repositoryies.Television
{
    public class TvCelebrityRepository : BaseRepository<TvCelebrity>, ITvCelebrityRepository
    {
        public TvCelebrityRepository(KzDbContext kzDbContext) : base(kzDbContext)
        {
        }

        public TvCelebrity GetByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Citizen.Name == name);
        }
    }
}
