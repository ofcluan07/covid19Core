using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RiskDegree.Models;

namespace RiskDegree.Controllers
{
    public class VariacoesWebController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<VariacoesWeb> variacoesWebList = new List<VariacoesWeb>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://covid19-brazil-api.now.sh/api/report/v1"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var dados = JsonConvert.DeserializeObject<VariacoesWebListData>(apiResponse);
                    variacoesWebList = dados.conteudo;
                }
            }
            List<QuantidadesWeb> listTotal = new List<QuantidadesWeb>();
            listTotal.Add(new QuantidadesWeb
            {
                Descricao = "Casos",
                Quantidade = Convert.ToInt32(variacoesWebList.Sum(x => x.cases))
            });

            listTotal.Add(new QuantidadesWeb
            {
                Descricao = "Suspeitos",
                Quantidade = Convert.ToInt32(variacoesWebList.Sum(x => x.suspects))
            });
            listTotal.Add(new QuantidadesWeb
            {
                Descricao = "Mortes",
                Quantidade = Convert.ToInt32(variacoesWebList.Sum(x => x.deaths))
            });
            listTotal.Add(new QuantidadesWeb
            {
                Descricao = "Recuperados",
                Quantidade = Convert.ToInt32(variacoesWebList.Sum(x => x.refuses))
            });

            ViewBag.Dados = listTotal;

            return View(variacoesWebList);
        }
    }
}