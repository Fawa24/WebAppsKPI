using Lab_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_2.Databases
{
	public class BooksDbContext : DbContext
	{
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }

		public BooksDbContext(DbContextOptions<BooksDbContext> options)
		: base(options)
		{

		}
	}
}
