using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.EnitiesDTO
{
    public class MaterialForCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
