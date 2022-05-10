#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MELISSA.Data;
using MELISSA.Models;

namespace MELISSA.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly MELISSA.Data.MELISSAContext _context;

        public EditModel(MELISSA.Data.MELISSAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mel Mel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mel = await _context.Mel.FirstOrDefaultAsync(m => m.ID == id);

            if (Mel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Mel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MelExists(Mel.ID))
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

        private bool MelExists(int id)
        {
            return _context.Mel.Any(e => e.ID == id);
        }
    }
}
