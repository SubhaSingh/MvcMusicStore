using DataAnnotationsValidations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;


namespace MvcMusicStore.Models
{
    public class Order
    {
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }
        [Display(Name ="Order Date")]
        public DateTime OrderDate { get; set; }
        public string Username { get; set; }
        [Required]
        [StringLength(160, MinimumLength=3)]
        [Display(Name = "Last Name", Order = 15000)]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Your {(0)} is required.")]
        [StringLength(160)]
        [MaxWords(10, ErrorMessage = "There are too many words in {0}")]
        [Display(Name = "Last Name", Order = 15001) ]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email doesn't look like a valid email address.")]
        public string Email { get; set; }
        [Range(typeof(decimal), "0.00", "49.99")]
        public decimal Total { get; set; }
    }


}