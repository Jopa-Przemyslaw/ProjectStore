//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectStore.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class UserTable
    {
        [Key]
        [Display(Name = "UserID")]
        public int UserID { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "This field is required.", AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required.", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "IsAdmin")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Age")]
        [Range(1, 100, ErrorMessage = "Age should be in range 1-100.")]
        public Nullable<int> Age { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "This field is required.", AllowEmptyStrings = false)]
        [RegularExpression("^[A-Z].*", ErrorMessage = "Your first name should starts with capital letter.")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        public string LastName { get; set; }
    }
}