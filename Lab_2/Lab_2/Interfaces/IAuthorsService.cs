using Lab_1.Models;

namespace Lab_1.Interfaces
{
	public interface IAuthorsService
	{
		public Task<List<Author>> GetAllAuthors();
		public Task<Author?> GetAuthorById(string id);
		public Task<bool> DeleteAuthorById(string id);
		public Task<bool> AddAuthor(Author author);
		public Task<bool> UpdateAuthor(Author author, string authorId);
	}
}
