using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nsProduct
{
    public class Product{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<Category> Categories { get; set; }
        [Required]
        public List<URL> ImageURLs { get; set; }
        [Required]
        public int StoreId { get; set; }
    }
    public class URL{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}