﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Me.DAL.Model
{
    public class Product : BaseEntity<int>
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int? BrandId { get; set; }
        public ProductBrand Brand { get; set; }
        public int? TypeId { get; set; } 
        public  productType Type { get; set; }

        
        public List<ProductRestaurant> ProductRestaurant { get; set; }

    }
}
