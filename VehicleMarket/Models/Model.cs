﻿using System.ComponentModel.DataAnnotations;

namespace VehicleMarket.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }
        public Make Make { get; set; }
        [Required]
        [Display(Name = "Make")]
        public int MakeId { get; set; }
    }
}
