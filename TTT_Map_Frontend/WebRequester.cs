using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TTT_Map_Frontend.Structs;

namespace TTT_Map_Frontend
{
    public class WebRequester
    {
        public static string GetAllMapRatingsUrl { get; set; }

        private static readonly HttpClient client = new HttpClient();
        
        public async static Task<string> GetAllMapRatings()
        {
            var response = await client.GetStringAsync(GetAllMapRatingsUrl);
            return response;            
        }

        public async static Task<string> PostRating(string rating)
        {
            var content = new StringContent(rating, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(GetAllMapRatingsUrl, content);
            
            return response.StatusCode.ToString();
        }
    }
}
