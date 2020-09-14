using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyGarageSale.Model;
using MyGarageSale.Pages;


namespace MyGarageSale.Pages.MyGarageSalePages

{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public IEnumerable<ItemForSale> Items { get; set; }


        public async Task OnGet()
        {
            Items = await _db.ItemForSale.ToListAsync();
        }



        public async Task<IActionResult> OnPostDelete(int id)
        {
            var item = await _db.ItemForSale.FindAsync(id);
            if (item == null)
            {
                return NotFound(item);
            }
            _db.ItemForSale.Remove(item);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
