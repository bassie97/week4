using System;
using System.Collections.Generic;

namespace Energieweb.Models
{
    public partial class Postcode
    {
        public int Id { get; set; }
        public string Postcode1 { get; set; }
        public long PostcodeId { get; set; }
        public int Pnum { get; set; }
        public string Pchar { get; set; }
        public int Minnumber { get; set; }
        public int Maxnumber { get; set; }
        public string Numbertype { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int? CityId { get; set; }
        public string Municipality { get; set; }
        public int? MunicipalityId { get; set; }
        public string Province { get; set; }
        public string ProvinceCode { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lon { get; set; }
        public decimal? RdX { get; set; }
        public decimal? RdY { get; set; }
        public string LocationDetail { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
