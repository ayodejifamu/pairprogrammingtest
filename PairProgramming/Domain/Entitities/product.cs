﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitities
{
    public class product
    {
        public string productName { get; set; }
        public string productId { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
