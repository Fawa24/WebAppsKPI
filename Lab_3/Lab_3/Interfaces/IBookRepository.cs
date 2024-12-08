using Lab_1.Models;

namespace Lab_2.Interfaces
{
	public interface IBookRepository
	{
		public Task<List<Book>> GetAllBooks();

		public Task<Book?> GetBookById(string id);

		public Task AddBook(Book book);

		public Task<bool> DeleteBookById(string id);

		public Task<bool> UpdateBook(Book book);

		public Task<List<Author>> GetAllAuthors();

		public Task<Author?> GetAuthorById(string id);

		public Task AddAuthor(Author author);

		public Task<bool> DeleteAuthorById(string id);

		public Task<bool> UpdateAuthor(Author author);
	}
}
