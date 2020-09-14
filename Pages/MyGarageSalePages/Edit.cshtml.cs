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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ItemForSale ItemForSale { get; set; }



        public async Task OnGet(int id)
        {
            ItemForSale = await _db.ItemForSale.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var itemFromDb = await _db.ItemForSale.FindAsync(ItemForSale.Id);
                itemFromDb.ItemCategory = ItemForSale.ItemCategory;
                itemFromDb.ItemName = ItemForSale.ItemName;
                itemFromDb.ItemModel = ItemForSale.ItemModel;
                itemFromDb.ItemManufacturer = ItemForSale.ItemManufacturer;
                itemFromDb.ItemPrice = ItemForSale.ItemPrice;
                itemFromDb.ItemDescription = ItemForSale.ItemDescription;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();            
        }
    }
}
