using Microsoft.EntityFrameworkCore;
using PopePhransisBookStore.Model;

namespace PopePhransisBookStore.Data
{

    public static class SeedData
        {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
              
                context.Database.Migrate();

               if (!context.PopePhransisBookStore.Any())
                {
                    context.PopePhransisBookStore.AddRange(
                        new Book { BookName = "The Pragmatic Programmer", Category = "Programming", Price = 45.99m, Description = "A guide to becoming a better programmer." },
                        new Book { BookName = "Clean Code", Category = "Programming", Price = 40.00m, Description = "A handbook on writing clean and maintainable code." },
                        new Book { BookName = "You Don't Know JS: Scope & Closures", Category = "Programming", Price = 25.00m, Description = "A deep dive into JavaScript's core mechanisms." },
                        new Book { BookName = "Eloquent JavaScript", Category = "Programming", Price = 35.99m, Description = "A modern introduction to JavaScript and web development." },
                        new Book { BookName = "C# in Depth", Category = "Programming", Price = 50.00m, Description = "Comprehensive guide to advanced C# programming concepts." },

                      
                        new Book { BookName = "Design Patterns: Elements of Reusable Object-Oriented Software", Category = "Software Engineering", Price = 55.99m, Description = "Influential book on software design patterns." },
                        new Book { BookName = "Refactoring: Improving the Design of Existing Code", Category = "Software Engineering", Price = 45.00m, Description = "A guide to refactoring code for better structure and performance." },
                        new Book { BookName = "The Mythical Man-Month", Category = "Software Engineering", Price = 38.99m, Description = "Essays on software project management." },
                        new Book { BookName = "Continuous Delivery", Category = "Software Engineering", Price = 50.50m, Description = "Guide on deploying software with automation and efficiency." },
                        new Book {  BookName = "Domain-Driven Design: Tackling Complexity in the Heart of Software", Category = "Software Engineering", Price = 60.00m, Description = "Techniques for managing software complexity using domain-driven design." },

                        
                        new Book {  BookName = "Introduction to Algorithms", Category = "Computer Science", Price = 75.50m, Description = "A comprehensive introduction to algorithms used worldwide." },
                        new Book {  BookName = "The Art of Computer Programming", Category = "Computer Science", Price = 199.99m, Description = "Comprehensive work on algorithms by Donald Knuth." },
                        new Book {  BookName = "Structure and Interpretation of Computer Programs", Category = "Computer Science", Price = 65.00m, Description = "A classic textbook on computer science fundamentals." },
                        new Book {  BookName = "Grokking Algorithms", Category = "Computer Science", Price = 40.00m, Description = "An illustrated guide to learning algorithms." },
                        new Book {  BookName = "Computer Networks", Category = "Computer Science", Price = 80.00m, Description = "Detailed guide on the principles and design of computer networks." }
                    );
                    context.SaveChanges();
                }
            }
        }
    }

}
