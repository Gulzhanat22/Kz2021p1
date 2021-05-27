using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Television
{
    public class CelebrityNewsViewModel
    {
        public TvCelebrityViewModel Celebrity { get; set; }
        public string Description { get; set; }
        public TvProgrammeViewModel Programme { get; set; }
    }
}
