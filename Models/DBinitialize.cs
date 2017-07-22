using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace iSnippets.Models
{
    public static class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new SnippetContext(
                serviceProvider.GetRequiredService<DbContextOptions<SnippetContext>>());
            context.Database.EnsureCreated();
        }
        
    }
}