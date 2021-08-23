using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace omdb_dal.Models
{
    public class Movies
    {
        [JsonProperty("Search")]
        public List<Movie> movies { get; set; }
        public int TotalResults { get; set; }
    }
}