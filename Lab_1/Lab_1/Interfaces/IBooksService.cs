using Lab_1.Models;

namespace Lab_1.Interfaces
{
	public interface IBooksService
	{
		public List<Book> GetAllBooks();
		public Book? GetBookById(string id);
		public bool DeleteBookById(string id);
		public bool AddBook(Book book);
		public bool UpdateBook(Book book, string bookId);
	}
}