using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LorensHuculak_ASP.ViewModels
{
    public class OwnerViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<CarViewModel> Cars { get; set; }
    }
}
