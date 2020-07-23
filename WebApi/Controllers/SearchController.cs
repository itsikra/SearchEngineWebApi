using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Models.SearchEngines;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    public class SearchController : ApiController
    {
        public string Get()
        {
            return "Please provide search word";           
        }

        public List<ResultDisplayObject> Get(string word)
        {
            List<string> resultStrings = new List<string>();

            List<ResultDisplayObject> searchResults = new List<ResultDisplayObject>();

            SearchEngineDbConnection db = new SearchEngineDbConnection();



            // get exising results from db
            searchResults = db.GetQueryResults(word);
            

            // if this is a new search
            if (searchResults == null || searchResults.Count == 0)
            {
                SearchEngine se = new BingEngine();
                searchResults = new List<ResultDisplayObject>();

                resultStrings = se.GetResultsFromHtml(word);

                foreach (string str in resultStrings)
                {
                    ResultDisplayObject listItem = new ResultDisplayObject() { SearchEngine = se.EngineName, Title = str };
                    searchResults.Add(listItem);
                    
                }

                // add to db
                db.AddQueryResults(se.EngineName, word, resultStrings);

                // add to cache (redis)
            }
            
            return searchResults;

        }
    }
}
