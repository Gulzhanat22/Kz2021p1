using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.EfStuff.Model.Television
{
    public class CelebrityNews : BaseModel
    {
        public virtual TvCelebrity Celebrity { get; set; }
        public string Description { get; set; }
        public virtual TvProgramme Programme { get; set; }
    }
}
