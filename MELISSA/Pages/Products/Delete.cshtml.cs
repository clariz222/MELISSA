#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MELISSA.Data;
using MELISSA.Models;

namespace MELISSA.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly MELISSA.Data.MELISSAContext _context;

        public DeleteModel(MELISSA.Data.MELISSAContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mel = await _context.Mel.FindAsync(id);

            if (Mel != null)
            {
                _context.Mel.Remove(Mel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
