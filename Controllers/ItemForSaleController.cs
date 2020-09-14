using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGarageSale.Model;

namespace MyGarageSale.Controllers
{
    [Route("api/ItemForSale")]
    [ApiController]
    public class ItemForSaleController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ItemForSaleController(ApplicationDbContext db)
        {
               _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.ItemForSale.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var itemFromDb = await _db.ItemForSale.FirstOrDefaultAsync(u => u.Id == id);
               if (itemFromDb == null)
            {
                return Json(new { success = false, message="Error while Deleting" });
            }
            _db.ItemForSale.Remove(itemFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deleted successfully." });
        }

    }
}
