﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    public class MyFighter : Character
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}