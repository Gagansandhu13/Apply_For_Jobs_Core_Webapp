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
    //Removes a candidate from databse.
    public class DeleteModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public DeleteModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }

        //Binds the cadidate model.
        [BindProperty]
        public Candidate Candidate { get; set; }

        //Gets the candidate for delete using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candidate =  _context.Candidate.FirstOrDefault(m => m.Id == id);

            if (Candidate == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the candidate used a linq query to get the record.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candidate = (from candidate in _context.Candidate

                         where candidate.Id == id
                         select candidate).FirstOrDefault();

            if (Candidate != null)
            {
                _context.Candidate.Remove(Candidate);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
