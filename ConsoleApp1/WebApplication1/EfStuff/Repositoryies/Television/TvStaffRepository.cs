using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;
using WebApplication1.EfStuff.Repositoryies.Television.Interface;

namespace WebApplication1.EfStuff.Repositoryies.Television
{
    public class TvStaffRepository : BaseRepository<TvStaff>, ITvStaffRepository
    {
        public TvStaffRepository(KzDbContext kzDbContext) : base(kzDbContext)
        {
        }

        public List<TvStaff> GetByChannel(string channelName)
        {
            return _dbSet.Where(x => x.Channel.Name == channelName).ToList();
        }

        public TvStaff GetByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Citizen.Name == name);
        }

        public bool HasTvAdmin()
        {
            return _dbSet.Any(x => x.Occupation == Occupation.TvAdmin);
            
        }
    }
}
