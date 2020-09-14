using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyGarageSale.Model;

namespace MyGarageSale.Pages.MyGarageSalePages
{
    public class CreateModel : PageModel

    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ItemForSale ItemForSale { get; set; }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost(ItemForSale itemObj)
        {
            if (ModelState.IsValid)
            {
                await _db.ItemForSale.AddAsync(ItemForSale);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
