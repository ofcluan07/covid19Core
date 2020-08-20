using System;
using System.Collections.Generic;

namespace RiskDegree.Models
{
    public partial class Patologia
    {
        public Patologia()
        {
            Consulta = new HashSet<Consulta>();
            Variacoes = new HashSet<Variacoes>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Variacoes> Variacoes { get; set; }
    }
}
