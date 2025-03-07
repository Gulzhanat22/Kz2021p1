﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;

namespace WebApplication1.EfStuff.Repositoryies.Television.Interface
{
    public interface ITvScheduleRepository : IBaseRepository<TvSchedule>
    {
        List<TvSchedule> GetByChannelAndDate(string channelName, DateTime date);
        bool TimeIsFree(DateTime date);
        List<TvSchedule> CheckForTranslation(DateTime date1, DateTime date2);
    }
}
