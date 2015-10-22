using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using NA.Domain.DomainClasses;

namespace NA.Web.Models.Account
{
    public class AddressViewModel
    {

        public AddressViewModel()
        {
            var addresses = from AddressType a in Enum.GetValues(typeof(AddressType))
                            select new { Id = (int)a, Name = a.ToString() };
            this.AddressTypes = new SelectList(addresses, "Id", "Name");
            this.AddressType = -1;
        }

        public string Street { get; set; }

        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [Display(Name = "Address type")]
        public int? AddressType { get; set; }

        public SelectList AddressTypes { get; set; }
    }
}