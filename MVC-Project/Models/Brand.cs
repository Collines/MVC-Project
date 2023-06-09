﻿using Microsoft.Build.Framework;
using shopping.Models;

namespace shopping.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
