﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carShop.Entities
{
    public partial class Cart
    {
        public int Id { get; set; }
    }

    public partial class Cart
    {
        public ICollection<Car>? Cars { get; set; }
    }
}