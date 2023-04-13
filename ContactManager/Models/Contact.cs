using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ContactManager.Models
{
    public class Contact
    {
        //primary key
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a email.")]
        public string Email { get; set; } = string.Empty;

        public DateTime DateAdded { get; set; }

        //Foreign Key
        [Range(1, Int32.MaxValue, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;

        //Read-only Slug property added to URL
        public string Slug => FirstName?.Replace(' ', '-').ToLower() + LastName?.Replace(' ', '-').ToLower();
    }
}
