using Newtonsoft.Json;
using omdb_dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace omdb_dal
{
    public class HTTPConnector : HttpClient
    {
        private static HttpClient client = new HttpClient();
        public const string BASE_API_URL = "http://www.omdbapi.com/?apikey=8e528186";

        public static async Task<Movies> getContentsFromAPI(String APIContentType)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(HTTPConnector.BASE_API_URL + "&type=" + APIContentType);

                if (response.IsSuccessStatusCode)
                {
                    var results = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Movies>(results);
                }

            }

            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return null;
        }

        public static async Task<Movie> getSpecificContentFromAPI(String IMDBId)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(HTTPConnector.BASE_API_URL + "&i=" + IMDBId + "&plot=full");

                if (response.IsSuccessStatusCode)
                {

                    var results = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Movie>(results);
                }

            }

            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return null;
        }

        public static async Task<Movies> getAPIByTitleAndType(String title, String type, String page)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(HTTPConnector.BASE_API_URL + "&s=" + title + "&type=" + type + "&page=" + page);

                if (response.IsSuccessStatusCode)
                {
                    var results = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Movies>(results);
                }

            }

            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return null;
        }

        public static async Task<int> getNumberOfSeasonsFromAPI(String IMDBId)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(HTTPConnector.BASE_API_URL + "&i=" + IMDBId + "&Season=1");

                if (response.IsSuccessStatusCode)
                {
                    var results = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Series>(results).TotalSeasons;
                }

            }

            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return -1;
        }

        public static async Task<Series> getSeasonByIDFromAPI(String IMDBId, int SeasonID)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(HTTPConnector.BASE_API_URL + "&i=" + IMDBId + "&Season=" + SeasonID);

                if (response.IsSuccessStatusCode)
                {
                    var results = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Series>(results);
                }

            }

            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return null;
        }
    }
}