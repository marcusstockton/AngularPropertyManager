using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPropertyManager.Models
{
    public class Portfolio : Base
    {
        public string Name { get; set; }
        public ApplicationUser Owner { get; set; }
        public virtual List<Property> Properties{ get; set; }
    }
}
