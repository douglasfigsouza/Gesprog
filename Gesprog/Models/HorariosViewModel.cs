using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gesprog.Models
{
    public class HorariosViewModel
    {

        public IEnumerable<HORARIOS> SelectedHorarios { get; set; }
        public IEnumerable<HORARIOS> AvailableHorarios { get; set; }
        public PostedHorarios PostedHorarios { get; set; }
    }
}