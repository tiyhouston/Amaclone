using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using nsProduct;

namespace nsStore{ 
    public class Store{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public List<Product> Products { get; set; }
    }
}
public partial class DB : DbContext {
    public DbSet<nsStore.Store> Stores {get;set;}
}