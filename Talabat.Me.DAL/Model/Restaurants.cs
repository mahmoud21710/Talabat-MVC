﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Me.DAL.Model
{
    public class Restaurants :BaseEntity<int>
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string PictureUrl { get; set; }


        public List<ProductRestaurant> ProductRestaurant { get; set; }

    }
}
