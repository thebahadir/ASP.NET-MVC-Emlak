using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeEmlak.Models
{
    public class ChangePassword
    {
        [Required]
        [DisplayName("Eski Şifre")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifre")]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="Şifre 5 ile 50 Karakter Uzunluğunda Olmalıdır!")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Şifre (Tekrar)")]
        [Compare("NewPassword", ErrorMessage = "Şifre Uyuşmuyor!")]
        public string ConNewPassword { get; set; }
        
    }
}