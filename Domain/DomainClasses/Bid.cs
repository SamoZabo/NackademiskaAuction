﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Bid
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
    }
}
