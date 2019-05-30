using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public abstract class RegistrationUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        public string ConfirmEmail { get; set; }

        [Required]
        public string MessageNotify { get; set; }

        [Required]
        public string AdNotify { get; set; }

        [Required]
        public string ArtifactNotify { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Пароль должен содержать не менее 6 символов")]
        public string Password { get; set; }
    }
}
