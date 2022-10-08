using System.ComponentModel.DataAnnotations;

namespace Web.VinFast.DTOs
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string? Password { get; set; }

    }
}
