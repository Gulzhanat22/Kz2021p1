using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;
using WebApplication1.EfStuff.Repositoryies.Television.Interface;

namespace WebApplication1.EfStuff.Repositoryies.Television
{
    public class TvScheduleRepository : BaseRepository<TvSchedule>, ITvScheduleRepository
    {
        public TvScheduleRepository(KzDbContext kzDbContext) : base(kzDbContext)
        {
        }

        public List<TvSchedule> GetByChannelAndDate(string channelName, DateTime date)
        {
            return _dbSet.Where(x => x.Programme.Channel.Name == channelName && x.AiringTime.Date == date.Date).OrderBy(x => x.AiringTime).ToList();
        }

        public bool TimeIsFree(DateTime date)
        {
            return !_dbSet.Any(x => x.AiringTime < date && x.EndAiringTime > date);
        }

        public List<TvSchedule> CheckForTranslation(DateTime date1, DateTime date2)
        {
            return _dbSet.Where(x => x.AiringTime <= date1 && x.EndAiringTime > date1 || (x.AiringTime < date2 && x.EndAiringTime >= date2))
                .ToList();
        }
    }
}
