using System;
using System.Collections.Generic;

namespace Energieweb.Models
{
    public partial class Apparaat
    {
        public Apparaat()
        {
            ApparaatHuishouden = new HashSet<ApparaatHuishouden>();
        }

        public long Id { get; set; }
        public string Naam { get; set; }
        public int? Max { get; set; }
        public string Merk { get; set; }
        public long? TypeFk { get; set; }

        public Type TypeFkNavigation { get; set; }
        public ICollection<ApparaatHuishouden> ApparaatHuishouden { get; set; }
    }
}
