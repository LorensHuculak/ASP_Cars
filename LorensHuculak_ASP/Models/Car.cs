using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VehiclistTest.Models
{
    public class Car
    {
        public int CarID { get; set; }

        public string Color { get; set; }

        [Display(Name = "Purchase Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
    
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }

        [Display(Name = "Brand")]
        public int CarTypeID { get; set; }

        [Display(Name = "Model")]
        public virtual CarType CarType { get; set; }

        [Display(Name = "Owner")]
        [DisplayFormat(NullDisplayText = "No Owner")]
        public int? OwnerID { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
