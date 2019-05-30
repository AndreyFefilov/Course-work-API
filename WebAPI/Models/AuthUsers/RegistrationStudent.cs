using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class RegistrationStudent : RegistrationUser
    {
        [Required]
        public int ClusterId { get; set; }

        public string ResultNotify { get; set; }
    }
}
