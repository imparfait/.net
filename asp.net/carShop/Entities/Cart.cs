﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carShop.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}