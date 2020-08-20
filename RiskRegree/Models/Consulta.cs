using System;
using System.Collections.Generic;

namespace RiskDegree.Models
{
    public partial class Consulta
    {
        public int? Id { get; set; }
        public int? Ip { get; set; }
        public string Device { get; set; }
        public DateTime? DataHora { get; set; }
        public int? Idpatologia { get; set; }
    }
}
