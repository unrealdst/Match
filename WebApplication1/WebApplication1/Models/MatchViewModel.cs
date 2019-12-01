using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MatchViewModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<string> Winners { get; set; }
        public bool IsCurrent { get; set; }
    }
}