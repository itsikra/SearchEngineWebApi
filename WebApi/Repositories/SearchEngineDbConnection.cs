using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using WebApi.Models;
using System.Data;
using WebApi.DbUtil;

namespace WebApi.Repositories
{
    public class SearchEngineDbConnection
    {
        public List<ResultDisplayObject> GetQueryResults(string searchTerm)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DbHelper.ConnectionString("SearchEngineDB")))
            {
                // todo: change to stored procedure to prevent injections
                List<ResultDisplayObject> output = connection.Query<ResultDisplayObject>($"select SearchEngine, Title, EnteredDate from Searches where SearchTerm = '{ searchTerm }' ").ToList();
                return output;
            }
        }

        public void AddQueryResults(string searchEngine, string searchTerm, List<string> searchResults)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DbHelper.ConnectionString("SearchEngineDB")))
            {
                
                DateTime time = DateTime.Now;              // Use current time
                string format = "yyyy-MM-dd";    // modify the format depending upon input required in the column in database 
                string currentTime = time.ToString(format);

                // change to bulk insert with stored procedure
                foreach (string title in searchResults)
                {
                    string cleanTitle = title.Replace("\"", "").Replace("'", "");
                    //connection.Execute($"insert into [dbo].Searches (SearchEngine, SearchTerm, Title, EnteredDate) values ('" + searchEngine + "', '" + searchTerm +"', '" +  title + "', '"+ currentTime +"'");
                    connection.Execute($"insert into [dbo].Searches (SearchEngine, SearchTerm, Title, EnteredDate) values ('{ searchEngine }', '{ searchTerm }', '{ cleanTitle }', '{ currentTime }')");
                }
                
            }
        }


    }
}