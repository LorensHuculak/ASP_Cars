using System.Collections.Generic;
using LorensHuculak_ASP.Models;

namespace LorensHuculak_ASP.ViewModels
{
    public class OwnerIndexData
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
    }
}
