﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Entities
{
    public class Artifact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }
        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; }

        public DateTime? DateSend { get; set; }

        public int StudentId { get; set; }
        public User Student { get; set; }

        public int TeacherId { get; set; }
        public User Teacher { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
