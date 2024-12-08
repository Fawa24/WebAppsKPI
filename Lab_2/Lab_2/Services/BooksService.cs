using Lab_1.Interfaces;
using Lab_1.Models;
using Lab_2.Interfaces;

namespace Lab_1.Services
{
	public class BooksService : IBooksService
	{
		private readonly IBookRepository _bookRepository;

		public BooksService(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<bool> AddBook(Book book)
		{
			book.Id = Guid.NewGuid().ToString();
			await _bookRepository.AddBook(book);
			return true;
		}

		public async Task<bool> DeleteBookById(string id)
		{
			return await _bookRepository.DeleteBookById(id);
		}

		public async Task<List<Book>> GetAllBooks()
		{
			return await _bookRepository.GetAllBooks();
		}

		public async Task<Book?> GetBookById(string id)
		{
			return await _bookRepository.GetBookById(id);
		}

		public async Task<bool> UpdateBook(Book book, string bookId)
		{
			return await _bookRepository.UpdateBook(book);
		}
	}
}
