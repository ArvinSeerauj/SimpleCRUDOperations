using System.ComponentModel.DataAnnotations;

namespace WebCRUD.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Email Adress")]
        public string Email { get; set; }

        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        /// <summary>
        /// Concatenate first name and last name then return as full name
        /// </summary>
        [Display(Name = "Full Name")]
        public string FullName {
            get {
                if (string.IsNullOrEmpty(FirstName))
                    return null;
                else
                    return FirstName + " " + LastName;               
            }
        }
    }
}