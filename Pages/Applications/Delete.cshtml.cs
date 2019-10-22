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
    //Deletes an existing application.
    public class DeleteModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public DeleteModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }

        //Binds the application model.
        [BindProperty]
        public Application Application { get; set; }

        //Gets the application for deleting using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application = _context.Application
                .Include(a => a.Advertisement)
                .Include(a => a.Candidate).Include(a => a.Advertisement.Employer).FirstOrDefault(m => m.Id == id);

            if (Application == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the application . selects the appplication using a linq query.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application = (from application in _context.Application
                           where application.Id == id
                           select application).FirstOrDefault();

            if (Application != null)
            {
                _context.Application.Remove(Application);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
