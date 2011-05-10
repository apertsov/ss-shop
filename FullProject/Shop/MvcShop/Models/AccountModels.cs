using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Resources;
namespace MvcShop.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string Fisrt { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string Last { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

    }
    /*
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name =string.Format(Resources.Global.CurrentPassword))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "PassL", ErrorMessageResourceType = typeof(Global), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = Resources.Global.NewPass)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = Resources.Global.NewPassC)]
        [Compare("NewPassword", ErrorMessage = Resources.Global.PassC)]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = Resources.Global.UserName)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = Resources.Global.Pass)]
        public string Password { get; set; }

        [Display(Name = Resources.Global.Remem)]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = Resources.Global.UserName)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = Resources.Global.Email)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = Resources.Global.PassL, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = Resources.Global.Pass)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = Resources.Global.NewPassC)]
        [Compare("Password", ErrorMessage = Resources.Global.PassC)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = Resources.Global.FirstName)]
        public string Fisrt { get; set; }

        [Required]
        [Display(Name = Resources.Global.LastName)]
        public string Last { get; set; }

        [Required]
        [Display(Name = Resources.Global.Address)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = Resources.Global.Phone)]
        public string Phone { get; set; }

    }*/
}
