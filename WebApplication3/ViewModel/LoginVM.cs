using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModel
{
    public class LoginVM
    {
        public string UserNameOrEmail { get; set; } = null!;

        [MaxLength(255), DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
