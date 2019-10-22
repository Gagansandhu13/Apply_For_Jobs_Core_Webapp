using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apply_For_Jobs_Core_Webapp.BusinessLayer;
using Apply_For_Jobs_Core_Webapp.Models;

namespace Apply_For_Jobs_Core_Webapp.Pages.Employers
{
    //Deletes an employer.
    public class DeleteModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public DeleteModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }

        //Binds the employer model.
        [BindProperty]
        public Employer Employer { get; set; }

        //Gets the employer for delete using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employer =  _context.Employer.FirstOrDefault(m => m.Id == id);

            if (Employer == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes a employer from databse uses a liq query to get the employer.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employer = (from employer in _context.Employer
                        where employer.Id == id
                        select employer).FirstOrDefault();

            if (Employer != null)
            {
                _context.Employer.Remove(Employer);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
