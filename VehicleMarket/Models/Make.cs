﻿using System.ComponentModel.DataAnnotations;

namespace VehicleMarket.Models
{
    public class Make
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }


    }
}
