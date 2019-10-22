using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apply_For_Jobs_Core_Webapp.BusinessLayer;
using Apply_For_Jobs_Core_Webapp.Models;

namespace Apply_For_Jobs_Core_Webapp.Pages.Advertisements
{
    //Creats an advertisement.
    public class CreateModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public CreateModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }

        //Gets the advertisement create form.
        public IActionResult OnGet()
        {
        ViewData["EmployerId"] = new SelectList(_context.Set<Employer>(), "Id", "Name");
            ViewData["JobType"] = new SelectList(Enum.GetValues(typeof(JobType)));
            return Page();
        }

        //Binds the advertisement model.
        [BindProperty]
        public Advertisement Advertisement { get; set; }

        //Adds an advertisement to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Advertisement.Add(Advertisement);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}