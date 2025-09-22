using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Shop.Review.Entities;


namespace Shop.Review.Context
{
    public class ReviewContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=localhost,1436; initial Catalog=MicroserviceShopReviewDb; User=sa; Password=Onuracarsoy1907*");
        }
        public DbSet<Comment> Comments { get; set; }
    }
}
