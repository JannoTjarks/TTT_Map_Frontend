using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TTT_Map_Frontend.Structs;

namespace TTT_Map_Frontend.Pages
{
    public class AddRatingModel : PageModel
    {
        public string Message { get; private set; }



        public void OnGet()
        {
            foreach (var item in HttpContext.Request.Headers)
            {
                Message += item.ToString();
            }
            //Message = HttpContext.Request.Headers.Count.ToString();
        }

        public async Task OnPost()
        {
            if (Int32.TryParse(Request.Form["rating"], out int rating) && rating > 0 && rating <= 5)
            {
                string json = JsonConvert.SerializeObject(new Rating(0, rating, Request.Form["steamid"], Request.Form["map"]), Formatting.Indented);
                
                Message = await WebRequester.PostRating(json);
            }
            else
            {
                Message = "Ungueltige Bewertung. Nur Zahlen zwischen 1 und 5 sind gueltige Eingaben.";
            }                  
        }
    }
}