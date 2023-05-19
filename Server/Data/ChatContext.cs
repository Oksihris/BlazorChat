using BlazorChat.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Server.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
        }

        public DbSet <User> Users { get; set; }
        public DbSet <Message> Messages { get; set; }
    }
}
