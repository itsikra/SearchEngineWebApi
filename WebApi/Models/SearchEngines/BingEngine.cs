using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApi.Models.SearchEngines
{
    public class BingEngine : SearchEngine
    {
        public override string EngineName
        {
            get
            {
                return "Bing";
            }
        }

        public BingEngine()
        {

        }

        public override string EngineSearchUrl
        {
            get
            {
                return "https://www.bing.com/search?q=";
            }
        }

        public override List<string> GetResultsFromHtml(string searchTerm)
        {
            List<string> resultList = new List<string>();

            string uri = this.EngineSearchUrl + searchTerm;
            var html = new HtmlDocument();
            html.LoadHtml(new WebClient().DownloadString(uri));

            var results = html.GetElementbyId("b_results")
                .SelectNodes("//h2")
                .Select(n => n.InnerText)
                .Take(5);

            foreach (string res in results)
            {
                resultList.Add(res);
            }

            return resultList;
        }
    }
}