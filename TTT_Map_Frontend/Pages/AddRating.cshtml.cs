using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TTT_Map_Frontend.Structs;

namespace TTT_Map_Frontend.Pages
{
    public class AddRatingModel : PageModel
    {
        public string UserName { get; private set; }
        public string Message { get; private set; }

        public void OnGet()
        {
            foreach (var header in HttpContext.Request.Headers)
            {
                if (header.Key == "Authorization")
                {
                    string value = header.Value;
                    string decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(value.Replace("Basic ", "")));
                    UserName = decodedCredentials.Split(":")[0];
                }
            }
        }

        public async Task OnPost()
        {
            if (Int32.TryParse(Request.Form["rating"], out int ratingValue) && ratingValue > 0 && ratingValue <= 5)
            {
                var rating = new Rating();
                rating.Id = 0;
                rating.User = Request.Form["steamid"];
                rating.Value = ratingValue;
                rating.Map = Request.Form["map"];
                string json = JsonConvert.SerializeObject(rating, Formatting.Indented);
                
                Message = await WebRequester.PostRating(json);
            }
            else
            {
                Message = "Ungueltige Bewertung. Nur Zahlen zwischen 1 und 5 sind gueltige Eingaben.";
            }                  
        }
    }
}