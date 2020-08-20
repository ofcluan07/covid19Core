using System;
using System.Collections.Generic;

namespace RiskDegree.Models
{
    public partial class Variacoes
    {
        public int Id { get; set; }
        public int? Idpatologia { get; set; }
        public int? Dia { get; set; }
        public int? Ano { get; set; }
        public int? Mes { get; set; }
        public int? NumeroInfectados { get; set; }
        public int? NumeroMortes { get; set; }
        public int? NumeroRecuperados { get; set; }

        public virtual Patologia IdpatologiaNavigation { get; set; }
    }
}
