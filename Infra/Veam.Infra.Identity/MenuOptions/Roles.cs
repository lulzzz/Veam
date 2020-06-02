using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veam.Models
{
    public partial class ApplicationUser
    {

        [Display(Name = "Roles")]
        public bool ApplicationUserRole { get; set; } = false;

        [Display(Name = "Home")]
        public bool HomeRole { get; set; } = false;
    }
}