using System;
using System.Collections.Generic;

namespace Energieweb.Models
{
    public partial class Meting
    {
        public long Id { get; set; }
        public long AppHh { get; set; }
        public DateTime? Datum { get; set; }
        public TimeSpan? Tijd { get; set; }
        public int? Waarde { get; set; }

        public ApparaatHuishouden AppHhNavigation { get; set; }
    }
}
