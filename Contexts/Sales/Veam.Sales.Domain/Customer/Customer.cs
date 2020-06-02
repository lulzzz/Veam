using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veam.Core.Domain
{
    public class Customer 
    {
        public Customer()
        {
            
        }

        [StringLength(38)]
        [Display(Name = "Customer Id")]
        public string customerId { get; set; }

        [StringLength(50)]
        [Display(Name = "Customer Name")]
        [Required]
        public string customerName { get; set; }

        [StringLength(50)]
        [Display(Name = "Discription")]
        public string description { get; set; }

        [Display(Name = "Business scale")]
        public BusinessSize size { get; set; }

        //IBaseAddress
       [Display(Name = "Address Line 1")]
        [Required]
        [StringLength(50)]
        public string street1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(50)]
        public string street2 { get; set; }

        [Display(Name = "city")]
        [StringLength(30)]
        public string city { get; set; }

        [Display(Name = "province")]
        [StringLength(30)]
        public string province { get; set; }

        [Display(Name = "country")]
        [StringLength(30)]
        public string country { get; set; }
        //IBaseAddress

        [Display(Name = "Customer Contacts")]
        public List<CustomerLine> customerLine { get; set; } = new List<CustomerLine>();
    }
}
