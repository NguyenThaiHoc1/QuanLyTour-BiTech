using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class KhachHang
    {
        public KhachHang()
        {
        }

        [Key]
        public int idKhachHang { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        public string TenKH { get; set; }

        [Required(ErrorMessage = "Gioi Tinh is required.")]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w -]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        public virtual ICollection<Tour> Tours { get; set; }
    }
}
