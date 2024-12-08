using Lab_2.Models.DTOs;

namespace Lab_1.Interfaces
{
	public interface IBooksService
	{
		public Task<List<GetBookDTO>> GetAllBooks();
		public Task<GetBookDTO?> GetBookById(string id);
		public Task<bool> DeleteBookById(string id);
		public Task<bool> AddBook(AddBookDTO book);
		public Task<bool> UpdateBook(string id, UpdateBookDTO book);
	}
}