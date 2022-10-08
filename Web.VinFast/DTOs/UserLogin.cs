using System.ComponentModel.DataAnnotations;

namespace Web.VinFast.DTOs
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string? Password { get; set; }
    }
}
