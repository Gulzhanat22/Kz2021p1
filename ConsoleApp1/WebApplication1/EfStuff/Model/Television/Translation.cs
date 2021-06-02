using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.EfStuff.Model.Television
{
    public class Translation : BaseModel
    {
        public string Name { get; set; }
        public DateTime AiringTime { get; set; }
        public int Duration { get; set; }
    }
}
