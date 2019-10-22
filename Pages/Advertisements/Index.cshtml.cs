using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apply_For_Jobs_Core_Webapp.BusinessLayer;
using Apply_For_Jobs_Core_Webapp.Models;

namespace Apply_For_Jobs_Core_Webapp.Pages.Advertisements
{
    //Returns all advertisements.
    public class IndexModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public IndexModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }

        //Holds advertisement information.
        public IList<Advertisement> Advertisement { get;set; }

        //Returns all  advertising and employee mapping inoformation using lamda query.
        public void  OnGet()
        {
            Advertisement =  _context.Advertisement
                .Include(a => a.Employer).ToList();
        }
    }
}
