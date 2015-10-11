using NA.Domain.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NA.Domain;
using NA.Domain.DomainClasses;
using System.ComponentModel.DataAnnotations;

namespace NA.Web.Models.Product
{
    public class ProductViewModel
    {
        public ProductViewModel(Domain.DomainClasses.Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Provision = product.Provision;
            StartPrice = product.GetStartPrice();
            SupplierName = product.Supplier.Name;
            IsSold = product.IsSold;

            if (product is AntiqueProduct )
            {
                Type = ProductType.Antique;
                TimeEpoch = ((AntiqueProduct) product).TimeEpoch.ToString();
            }
            if (product is ModernProduct)
            {
                Type = ProductType.Modern;
                DesignerName = ((ModernProduct) product).Designer.Name;
            }
            if (product is MassProduct)
            {
                Type = ProductType.Mass;
                DesignerName = ((MassProduct)product).Designer.Name;
            }
        }


        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Provision { get; set; }
        [Display(Name="Start Price")]
        public decimal StartPrice { get; set; }
        [Display(Name = "Supplier")]

        public string SupplierName { get; set; }
        [Display(Name = "Sold")]

        public Boolean IsSold { get; set; }
        public ProductType Type { get; set; }
        [Display(Name = "Time Epoch")]

        public string TimeEpoch { get; set; }
        [Display(Name = "Designer")]

        public string DesignerName { get; set; }
    }
}