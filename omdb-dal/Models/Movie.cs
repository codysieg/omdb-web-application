using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace omdb_dal.Models
{
    public class Movie
    {

        [JsonProperty("imdbID")]
        public string ImdbID { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("Rated")]
        public string FilmRating { get; set; }

        [JsonProperty("Released")]
        public string ReleasedDate { get; set; }

        [JsonProperty("Runtime")]
        public string RunTimeLength { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Writer")]
        public string Writer { get; set; }

        [JsonProperty("Actors")]
        public string Actors { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("Awards")]
        public string Awards { get; set; }

        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }

        [JsonProperty("BoxOffice")]
        public string BoxOfficeRevenue { get; set; }

        [JsonProperty("Production")]
        public string Production { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

        [JsonProperty("Plot")]
        public string Plot { get; set; }

        [JsonProperty("Error")]
        public string Error { get; set; }

        // This is generated afterwards, not returned from the API.
        public bool isFavourited { get; set; }
    }
}