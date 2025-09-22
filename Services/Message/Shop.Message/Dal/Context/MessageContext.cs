using Microsoft.EntityFrameworkCore;
using Shop.Message.Dal.Entities;
namespace Shop.Message.Dal.Context
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) :base(options)
        {
                
        }

        public DbSet<UserMessage> UserMessages { get; set; }
    }

}
