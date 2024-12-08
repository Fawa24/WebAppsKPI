using Lab_2.Models.DTOs;

namespace Lab_1.Interfaces
{
	public interface IAuthorsService
	{
		public Task<List<GetAuthorDTO>> GetAllAuthors();
		public Task<GetAuthorDTO?> GetAuthorById(string id);
		public Task<bool> DeleteAuthorById(string id);
		public Task<bool> AddAuthor(AddAuthorDTO author);
		public Task<bool> UpdateAuthor(string id, UpdateAuthorDTO author);
	}
}
