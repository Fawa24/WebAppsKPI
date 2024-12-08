using Lab_1.Models;
using Lab_2.Databases;
using Lab_2.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Lab_2.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly BooksDbContext _db;

		public BookRepository(BooksDbContext db)
		{
			_db = db;
		}

		public async Task<List<Book>> GetAllBooks()
		{
			Log.Information("GetAllBooks was called");
			return await _db.Books.Include(x => x.Author).ToListAsync();
		}

		public async Task<Book?> GetBookById(string id)
		{
			Log.Information("GetBookById was called");
			return await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<bool> DeleteBookById(string id)
		{
			Log.Information("DeleteBookById was called");
			var bookToRemove = await _db.Books.FindAsync(id);
			if (bookToRemove != null)
			{
				_db.Books.Remove(bookToRemove);
				await _db.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<List<Author>> GetAllAuthors()
		{
			Log.Information("GetAllAuthors was called");
			return await _db.Authors.ToListAsync();
		}

		public async Task<Author?> GetAuthorById(string id)
		{
			Log.Information("GetAuthorById was called");
			return await _db.Authors.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<bool> DeleteAuthorById(string id)
		{
			Log.Information("DeleteAuthorById was called");
			var autorToRemove = await _db.Authors.FindAsync(id);
			if (autorToRemove != null)
			{
				_db.Authors.Remove(autorToRemove);
				await _db.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task AddBook(Book book)
		{
			Log.Information("AddBook was called");
			await _db.Books.AddAsync(book);
			await _db.SaveChangesAsync();
		}

		public async Task<bool> UpdateBook(Book book)
		{
			Log.Information("UpdateBook was called");
			_db.Books.Update(book);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task AddAuthor(Author author)
		{
			Log.Information("AddAuthor was called");
			await _db.Authors.AddAsync(author);
			await _db.SaveChangesAsync();
		}

		public async Task<bool> UpdateAuthor(Author author)
		{
			Log.Information("UpdateAuthor was called");
			_db.Authors.Update(author);
			await _db.SaveChangesAsync();
			return true;
		}
	}
}
