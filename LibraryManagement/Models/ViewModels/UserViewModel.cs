using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
    public class UserProfileViewModel
    {
        
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }

    public class LoginUserViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    
}
