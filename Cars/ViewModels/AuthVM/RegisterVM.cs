using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModels.AuthVM
{
    public class RegisterVM
    {

        [Required(ErrorMessage ="Enter name and surname"),MaxLength(36)]
        public string Fullname { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter username"), MaxLength(32)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        public string PasswordConfirmed { get; set; }
    }
}
