using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VehiclistTest.Models
{
    public class Owner
    {
        public int OwnerID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + Name;
            }
        }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
