using System;
using System.Collections.Generic;

namespace Energieweb.Models
{
    public partial class Huishouden
    {
        public Huishouden()
        {
            ApparaatHuishouden = new HashSet<ApparaatHuishouden>();
        }

        public long Id { get; set; }
        public string Postcode { get; set; }
        public int? Huisnummer { get; set; }
        public int? Grootte { get; set; }

        public ICollection<ApparaatHuishouden> ApparaatHuishouden { get; set; }
    }
}
