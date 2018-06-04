using Microsoft.EntityFrameworkCore;

namespace Model{
    public class LibraryContext :DbContext{
        
        public LibraryContext (DbContextOptions<LibraryContext> options):base(options)
        {
        }

        public DbSet<Book> Books {get;set;}

        public DbSet<Author> Authors {get;set;}

        public DbSet<Car> Car{get;set;}

        public DbSet<Manufacturer> Manufacturer {get;set;}

    };
};