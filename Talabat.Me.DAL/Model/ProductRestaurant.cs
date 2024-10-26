using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Me.DAL.Model
{
    public class ProductRestaurant 
    {
        public int RestaurantsId { get; set; }
        public int ProductsId { get; set; }
        public Restaurants Restaurants { get; set; }
        public Product Products { get; set; }
    }
}
