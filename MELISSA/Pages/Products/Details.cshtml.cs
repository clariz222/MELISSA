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
    public class DetailsModel : PageModel
    {
        private readonly MELISSA.Data.MELISSAContext _context;

        public DetailsModel(MELISSA.Data.MELISSAContext context)
        {
            _context = context;
        }

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
    }
}
