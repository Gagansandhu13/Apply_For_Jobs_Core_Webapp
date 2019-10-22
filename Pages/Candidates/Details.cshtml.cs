using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apply_For_Jobs_Core_Webapp.BusinessLayer;
using Apply_For_Jobs_Core_Webapp.Models;

namespace Apply_For_Jobs_Core_Webapp.Pages.Candidiates
{

    //Gets the details of a candidate.
    public class DetailsModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public DetailsModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }

        //Holds candidate information.
        public Candidate Candidate { get; set; }

        //Returns candidate details using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candidate = _context.Candidate.FirstOrDefault(m => m.Id == id);

            if (Candidate == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
