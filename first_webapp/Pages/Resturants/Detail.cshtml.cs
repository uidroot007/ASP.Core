using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using first_webapp.data;
using first_webapp_resturants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace first_webapp.Pages.Resturants
{
    public class DetailModel : PageModel
    {
        private readonly IResturantdata resturantdata;

        public Resturant Resturant {get; set; }
        public DetailModel(IResturantdata resturantdata)
        {
            this.resturantdata = resturantdata;
        }
        public IActionResult OnGet(int resturantId)
        {
            Resturant = resturantdata.GetById(resturantId);
            if(Resturant == null)
            {
                return RedirectToPage("./NotFound");
                            }
            return Page();
        }
    }
}
