using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ResultDisplayObject
    {

        public ResultDisplayObject()
        {
        }

        public string SearchEngine { get; set; }
        public string Title { get; set; }
        public DateTime EnteredDate { get; set; }
    }
}