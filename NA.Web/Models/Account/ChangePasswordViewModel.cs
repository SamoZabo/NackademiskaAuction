using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NA.Web.Models.Account
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Old password")]
        public string OldPassword { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("NewPassword")]
        [Display(Name = "Confirm new password")]
        public string ConfirmNewPassword { get; set; }

    }
}