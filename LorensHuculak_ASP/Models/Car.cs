using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LorensHuculak_ASP.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string LicensePlate { get; set; }
        public virtual CarType CarType { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
