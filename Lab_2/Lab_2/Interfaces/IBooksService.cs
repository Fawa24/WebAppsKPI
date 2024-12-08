using Lab_1.Models;

namespace Lab_1.Interfaces
{
	public interface IBooksService
	{
		public Task<List<Book>> GetAllBooks();
		public Task<Book?> GetBookById(string id);
		public Task<bool> DeleteBookById(string id);
		public Task<bool> AddBook(Book book);
		public Task<bool> UpdateBook(Book book, string bookId);
	}
}