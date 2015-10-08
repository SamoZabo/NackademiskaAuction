using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Provision { get; set; }
        public decimal StartPrice { get; set; }
        public Supplier Supplier { get; set; }
        public bool IsSold { get; set; }

        public virtual decimal GetStartPrice()
        {
            return StartPrice;
        }
    }
}
