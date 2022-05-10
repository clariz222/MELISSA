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
#pragma warning disable CS8618
#pragma warning disable CS8604
    public class IndexModel : PageModel
    {
        private readonly MELISSA.Data.MELISSAContext _context;

        public IndexModel(MELISSA.Data.MELISSAContext context)
        {
            _context = context;
        }

        public IList<Mel> Mel { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Brands { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BrandsProduct { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> brandQuery = from m in _context.Mel
                                            orderby m.Brand
                                            select m.Brand;
            var Products = from m in _context.Mel
                           select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Products = Products.Where(s => s.NameofProduct.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(BrandsProduct))
            {
                Products = Products.Where(x => x.Brand == BrandsProduct);
            }
            Brands = new SelectList(await brandQuery.Distinct().ToListAsync());
            Mel = await Products.ToListAsync();
        }



    }

#pragma warning disable CS8618
#pragma warning disable CS8604
    
}
