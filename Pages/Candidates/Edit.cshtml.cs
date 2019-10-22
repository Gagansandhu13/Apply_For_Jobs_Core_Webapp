using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apply_For_Jobs_Core_Webapp.BusinessLayer;
using Apply_For_Jobs_Core_Webapp.Models;

namespace Apply_For_Jobs_Core_Webapp.Pages.Candidiates
{
    //Updates a candidate.
    public class EditModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public EditModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }

        //Binds the candidate model.
        [BindProperty]
        public Candidate Candidate { get; set; }

        //Gets the candidate model for update using a lamda query.
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

        //Adds  a candidate to databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Candidate).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(Candidate.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks record existance using  a lamda query.
        private bool CandidateExists(int id)
        {
            return _context.Candidate.Any(e => e.Id == id);
        }
    }
}
