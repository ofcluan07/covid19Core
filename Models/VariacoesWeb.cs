using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RiskDegree.Models
{
    public class VariacoesWebListData
    {
        [JsonProperty("data")]
        public List<VariacoesWeb> conteudo;
    }

    public class VariacoesWeb
    {
        [Key]
        public int uid { get; set; }

        [DisplayName("UF")]
        public string uf { get; set; }

        [DisplayName("Estado")]
        public string state { get; set; }

        [DisplayName("Casos")]
        public int? cases { get; set; }

        [DisplayName("Mortes")]
        public int? deaths { get; set; }

        [DisplayName("Suspeitos")]
        public int? suspects { get; set; }

        [DisplayName("Recuperados")]
        public int? refuses { get; set; }

        [DisplayName("Data")]
        public DateTime datetime { get; set; }
    }
}
