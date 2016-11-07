using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace nsCategory
{
    public class Category{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

public partial class DB : DbContext {
    public DbSet<nsCategory.Category> Categories {get;set;}
}