using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apply_For_Jobs_Core_Webapp.BusinessLayer;
using Apply_For_Jobs_Core_Webapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Apply_For_Jobs_Core_Webapp.Pages.Applications
{
    //Creates an application.
    public class CreateModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public CreateModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }
        //Gets the application form.

        public IActionResult OnGet()
        {
        ViewData["AdvertisementId"] = new SelectList(_context.Advertisement.Include(ad => ad.Employer).ToList(), "Id", "AdvertisementDisplayId");
        ViewData["CandidateId"] = new SelectList(_context.Set<Candidate>(), "Id", "RegsitrationNumber");
            return Page();
        }

        //Bilds the application model.
        [BindProperty]
        public Application Application { get; set; }

        //Adds the application to databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Application.Add(Application);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}