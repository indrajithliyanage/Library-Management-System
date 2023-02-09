using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class ContactModel
    {
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name can't be empty!")]
        public string name { get; set; }
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email can't be empty!")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "The Email field is invalid.")]
        public string email { get; set; }
        [Display(Name = "Message")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Message can't be empty!")]
        [DataType(DataType.MultilineText)]
        public string message { get; set; }
    }
}