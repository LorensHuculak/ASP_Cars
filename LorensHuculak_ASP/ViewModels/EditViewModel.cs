using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LorensHuculak_ASP.ViewModels
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Owner { get; set; }
        public string Brand { get; set; }
        public int? OwnerId { get; set; }
        public int? BrandId { get; set; }
        public List<SelectListItem> Owners { get; set; }
        public List<SelectListItem> CarTypes { get; set; }
    }
}
