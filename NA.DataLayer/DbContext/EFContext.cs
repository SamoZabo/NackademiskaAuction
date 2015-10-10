﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NA.Domain.DomainClasses;

namespace NA.DataLayer.DbContext
{
    public class EFContext : System.Data.Entity.DbContext
    {
        public EFContext()
            : base("AuctionConnection")
        {

        }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MassProduct> MassProducts { get; set; }
        public DbSet<AntiqueProduct> AntiqueProducts { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<ModernProduct> ModernProducts { get; set; }

    }
}
