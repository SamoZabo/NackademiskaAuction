using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;
using System.Web.Mvc;
using NA.Domain.DomainClasses;
using NA.Domain.Factory;

namespace NA.Web.Models.Product
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public decimal Provision { get; set; }

        [Display(Name = "Start Price")]
        public decimal StartPrice { get; set; }

        [Display(Name="Product Type")]
        public SelectList ProductTypes { get; set; }
        public int ProductTypeId { get; set; }

        public SelectList Suppliers { get; set; }
        public Guid? SupplierId { get; set; }

        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        public SelectList Designers { get; set; }
        public Guid? DesignerId { get; set; }


        [Display(Name = "Designer Name")]
        public string DesignerName { get; set; }

        [Display(Name = "Time Epoch")]
        public SelectList TimeEpochs { get; set; }
        public int? TimeEpochId { get; set; }

    }
}