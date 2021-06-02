using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Television
{
    public class TranslationViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime AiringTime { get; set; }
        public int Duration { get; set; }
    }
}
