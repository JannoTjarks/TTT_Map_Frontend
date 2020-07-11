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
    public class IndexModel : PageModel
    {       
        public List<TableContent> TableContent { get; set; }      

        public async Task OnGet()
        {
            var json = await WebRequester.GetAllMapRatings();
            TableContent = JsonConvert.DeserializeObject<List<TableContent>>(json);            
        }
    }
}
