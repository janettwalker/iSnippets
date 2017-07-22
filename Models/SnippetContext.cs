using Microsoft.EntityFrameworkCore;

namespace iSnippets.Models
{
    public class SnippetContext : DbContext
    {
        public SnippetContext (DbContextOptions<SnippetContext> options)
            : base(options)
        {
        }

        public DbSet<iSnippets.Models.Snippet> Snippet { get; set; }
    }
}