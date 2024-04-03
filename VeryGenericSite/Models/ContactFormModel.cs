using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;

namespace VeryGenericSite.Models
{
    /// <summary>
    /// #THROWABLE! WRAP IN TRY CATCH AND RETURN FALSE ADDRESS ON CALL IN CONTROLLER
    /// needs to be initialized somewhere....
    /// </summary>
    public class ContactFormModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "name and lastname")]
        public string Name { get; set; }
        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephonenumber")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "emailaddress")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "StreetAddress that you wish us to Visit")]
        public string StreetAddress { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "PostalCode")]
        public string ZipCode { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "If you're in the US or Australia, Insert the state")]
        public string? State { get; set; }
        [Required]
        [Display(Name = "Country")]
        [DataType(DataType.Text)]
        public string Country { get; set; }
        [DataType(DataType.DateTime)]
        public string PreferredDate { get; set; }

    }
}
