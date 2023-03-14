﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManager.Domain.Models
{
    public class StadiumDTO
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } 
        [Required]
        [MaxLength(150)]
        public string Location { get; set; } 
        [Required]
        public int Capacity { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}