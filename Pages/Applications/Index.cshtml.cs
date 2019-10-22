using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apply_For_Jobs_Core_Webapp.BusinessLayer;
using Apply_For_Jobs_Core_Webapp.Models;

namespace Apply_For_Jobs_Core_Webapp.Pages.Applications
{
    //Returns all applications.
    public class IndexModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public IndexModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }

        //Holds all applications.
        public IList<Application> Application { get;set; }

        //Gets all applications using a lamda query.
        public void OnGet()
        {
            Application = _context.Application
                .Include(a => a.Advertisement)
                .Include(a => a.Candidate).Include(a=>a.Advertisement.Employer).ToList();
        }
    }
}
