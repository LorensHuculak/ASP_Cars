using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LorensHuculak_ASP.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + Name;
            }
        }
        public virtual List<Car> Cars { get; set; }
    }
}
