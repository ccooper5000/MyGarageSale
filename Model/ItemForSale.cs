using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyGarageSale.Model;

namespace MyGarageSale.Model
{
    public class ItemForSale
    {
        [Key]
        public int Id { get; set; }

        public string ItemCategory { get; set; }
        public string ItemName { get; set; }
        public string ItemModel { get; set; }
        public string ItemManufacturer { get; set; }
        public double ItemPrice { get; set; }
        public string ItemDescription { get; set; }

    }
}
