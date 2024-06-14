using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.UtilityModels
{
    public class Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Weight { get; set; }

        public int Quantity { get; set; }
    }
}
