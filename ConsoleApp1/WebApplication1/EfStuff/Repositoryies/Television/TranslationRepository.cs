using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model.Television;
using WebApplication1.EfStuff.Repositoryies.Television.Interface;

namespace WebApplication1.EfStuff.Repositoryies.Television
{
    public class TranslationRepository: BaseRepository<Translation>, ITranslationRepository
    {
        public TranslationRepository(KzDbContext kzDbContext) : base(kzDbContext)
        {
        }
    }
}
