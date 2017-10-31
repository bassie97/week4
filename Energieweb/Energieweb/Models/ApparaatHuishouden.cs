using System;
using System.Collections.Generic;

namespace Energieweb.Models
{
    public partial class ApparaatHuishouden
    {
        public ApparaatHuishouden()
        {
            Meting = new HashSet<Meting>();
        }

        public long Id { get; set; }
        public long? HuishoudenFk { get; set; }
        public long? ApparaatFk { get; set; }

        public Apparaat ApparaatFkNavigation { get; set; }
        public Huishouden HuishoudenFkNavigation { get; set; }
        public ICollection<Meting> Meting { get; set; }
    }
}
