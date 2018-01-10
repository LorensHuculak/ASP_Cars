using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LorensHuculak_ASP.Models
{
    public class CarType
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string FullBrand
        {
            get
            {
                return Brand + " " + Model;
            }
        }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
