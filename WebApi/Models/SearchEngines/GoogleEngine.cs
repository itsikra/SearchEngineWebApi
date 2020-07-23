using System.Collections.Generic;

namespace WebApi.Models.SearchEngines
{
    /// <summary>
    ///     CANCELED - GOOGLE MAY BLOCK SCRAPING USERS
    /// </summary>
    /// 
    public class GoogleEngine : SearchEngine
    {
        public GoogleEngine()
        {

        }

        public override string EngineName
        {
            get
            {
                return "Google";
            }
        }

        public override string EngineSearchUrl
        {
            get
            {
                return "www.google.com/search?q=";
            }
        }


        public override List<string> GetResultsFromHtml(string searchTerm)
        {
            return null;
        }
    }
}