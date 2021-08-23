using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace omdb_dal.Models
{
    public class Series
    {
        public string Title { get; set; }

        [JsonProperty("Season")]
        public string SeasonNumber { get; set; }

        public int TotalSeasons { get; set; }

        public List<Episode> Episodes { get; set; }

        public string Plot { get; set; }

        public string Error { get; set; }
    }
}