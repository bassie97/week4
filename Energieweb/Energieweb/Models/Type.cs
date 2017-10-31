using System;
using System.Collections.Generic;

namespace Energieweb.Models
{
    public partial class Type
    {
        public Type()
        {
            Apparaat = new HashSet<Apparaat>();
        }

        public long Id { get; set; }
        public string TypeNaam { get; set; }

        public ICollection<Apparaat> Apparaat { get; set; }
    }
}
