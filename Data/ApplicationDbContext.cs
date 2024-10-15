using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using PopePhransisBookStore.Model;

namespace PopePhransisBookStore.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser> (options)

    {

        
        public DbSet<Book> PopePhransisBookStore { get; set; }
        public DbSet<Category> BookCategory { get; set; }
    }
}
