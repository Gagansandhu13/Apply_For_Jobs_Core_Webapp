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
    //Gets the details of the application.
    public class DetailsModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public DetailsModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }

        //Holds the application.
        public Application Application { get; set; }

        //Gets the application details using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application =  _context.Application
                .Include(a => a.Advertisement)
                .Include(a => a.Candidate).Include(a=>a.Advertisement.Employer).FirstOrDefault(m => m.Id == id);

            if (Application == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
