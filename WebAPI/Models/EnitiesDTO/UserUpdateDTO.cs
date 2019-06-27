using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.EnitiesDTO
{
    public class UserUpdateDTO
    { 
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }
        public string MessageNotify { get; set; }
        public string AdNotify { get; set; }
        public string ArtifactNotify { get; set; }
        public int ClusterId { get; set; }
        public string ResultNotify { get; set; }
        public string PhotoUrl { get; set; }
    }
}
