using System.Collections.Generic;

namespace WebApi.Models.SearchEngines
{
    public abstract class SearchEngine
    {

        public abstract string EngineName { get; }
        public abstract string EngineSearchUrl { get; }
                

        public abstract List<string> GetResultsFromHtml(string searchTerm);
        
    }
}