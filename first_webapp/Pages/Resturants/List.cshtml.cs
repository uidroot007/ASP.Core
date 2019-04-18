using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using first_webapp.data;
using first_webapp_resturants;
namespace first_webapp.Pages.Resturants
{

    public class ListModel : PageModel
    {
        private string message;
        private readonly IResturantdata resturantdata;
        public string Message { get => message; set => message = value; }
        public IConfiguration config { get; }
        public IEnumerable<Resturant>Resturants { get; set; }
        [BindProperty(SupportsGet =true)] 
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IResturantdata resturantData)
        {
            this.config = config;
            this.resturantdata = resturantData;
        }
        public void OnGet()
        {


            Message = config["Message"];
            Resturants = resturantdata.GetResturantsByName(SearchTerm);
        }
    }
}
