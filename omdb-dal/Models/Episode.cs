using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace omdb_dal.Models
{
    public class Episode
    {
        [JsonProperty("imdbID")]
        public string ImdbID { get; set; }

        public string Title { get; set; }

        [JsonProperty("Episode")]
        public string EpisodeNumber { get; set; }

        public double IMDBRating { get; set; }

        public string Plot { get; set; }

        public string Poster { get; set; }


    }
}