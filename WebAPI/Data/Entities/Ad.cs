using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Ad
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public User User { get; set; }
    }
}
