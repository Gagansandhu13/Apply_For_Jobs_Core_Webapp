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
    //Deletes an advertisement.
    public class DeleteModel : PageModel
    {
        //The databse context.
        private readonly Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext _context;

        public DeleteModel(Apply_For_Jobs_Core_Webapp.Models.Apply_For_Jobs_Core_WebappDatabseContext context)
        {
            _context = context;
        }

        //Binds the advertisement model.
        [BindProperty]
        public Advertisement Advertisement { get; set; }

        //Gets the advertisement delete confirmation uses a lamda query to get the advertisement.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Advertisement =  _context.Advertisement
                .Include(a => a.Employer).FirstOrDefault(m => m.Id == id);

            if (Advertisement == null)
            {
                return NotFound();
            }
            return Page();
        }
        //Removes the advertisement uses a linq query to get the advertisement.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Advertisement = (from advertisement in _context.Advertisement
                             where advertisement.Id == id
                             select advertisement).FirstOrDefault();

            if (Advertisement != null)
            {
                _context.Advertisement.Remove(Advertisement);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
