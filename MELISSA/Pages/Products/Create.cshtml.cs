#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MELISSA.Data;
using MELISSA.Models;

namespace MELISSA.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly MELISSA.Data.MELISSAContext _context;

        public CreateModel(MELISSA.Data.MELISSAContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mel Mel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mel.Add(Mel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
