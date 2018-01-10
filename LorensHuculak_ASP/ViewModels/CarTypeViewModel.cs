using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LorensHuculak_ASP.ViewModels
{
    public class CarTypeViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public List<CarViewModel> Cars { get; set; }
    }
}
