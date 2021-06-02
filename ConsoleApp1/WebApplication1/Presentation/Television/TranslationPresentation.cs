using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;
using WebApplication1.EfStuff.Repositoryies.Television.Interface;
using WebApplication1.Models.Television;
using WebApplication1.Services;

namespace WebApplication1.Presentation.Television
{
    public class TranslationPresentation : ITranslationPresentation
    {
        private ITranslationRepository _translationRepository;
        public IMapper _mapper;
        public ITvProgrammeRepository _programmeRepository;
        public ITvScheduleRepository _scheduleRepository;
        public IUserService _userService;

        public TranslationPresentation(ITranslationRepository translationRepository, IMapper mapper, ITvProgrammeRepository programmeRepository,
            ITvScheduleRepository scheduleRepository, IUserService userService)
        {
            _translationRepository = translationRepository;
            _mapper = mapper;
            _programmeRepository = programmeRepository;
            _scheduleRepository = scheduleRepository;
            _userService = userService;
        }

        public List<TranslationViewModel> TranslationIndex()
        {
            return _translationRepository.GetAll().Select(_mapper.Map<TranslationViewModel>).ToList();
        }

        public void Save(TranslationViewModel viewModel)
        {
            var model = _mapper.Map<Translation>(viewModel);
            _translationRepository.Save(model);
        }

        public TranslationViewModel Find(long id)
        {
            var viewModel = _mapper.Map<TranslationViewModel>(_translationRepository.Get(id));
            return viewModel;
        }
        public TvProgramme ConvertTranslation(TranslationViewModel viewModel)
        {
            var programme = new TvProgramme()
            {
                Name = viewModel.Name + " (" + _userService.GetUser().TvStaff.Channel.Name + ")",
                Duration = viewModel.Duration,
                AvatarUrl = "/Image/Television/live.jpg",
                Channel = null,
                ContentRating = ContentRating.PG13,
                TypeOfProgramme = TypeOfProgramme.Live
            };
            _programmeRepository.Save(programme);
            return programme;
        }

        public void SaveSchedule(TranslationViewModel viewModel)
        {
            var programme = ConvertTranslation(viewModel);
            programme.Channel = _userService.GetUser().TvStaff.Channel;
            var schedule = new TvSchedule()
            {
                AiringTime = viewModel.AiringTime,
                Programme = programme,
                EndAiringTime = viewModel.AiringTime.AddMinutes(programme.Duration)
            };

            CheckingTime(schedule.AiringTime, schedule.EndAiringTime);

            SaveInScheduleRepository(schedule);
        }

        public void SaveInScheduleRepository(TvSchedule schedule)
        {
            _scheduleRepository.Save(schedule);
        }

        public void CheckingTime(DateTime date1, DateTime date2)
        {
            var scheduleProgramme = _scheduleRepository.CheckForTranslation(date1, date2);
            if (scheduleProgramme != null)
            {
                foreach (var item in scheduleProgramme)
                {
                    _scheduleRepository.Remove(item);
                }
            }
        }

    }
}
