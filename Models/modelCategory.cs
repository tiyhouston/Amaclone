using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nsCategory
{
    public class Category{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Name { get; set; }
    }
}