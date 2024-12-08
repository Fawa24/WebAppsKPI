using Lab_1.Interfaces;
using Lab_1.Models;
using Lab_2.Interfaces;

namespace Lab_1.Services
{
	public class AuthorService : IAuthorsService
	{
		private readonly IBookRepository _bookRepository;

		public AuthorService(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<bool> AddAuthor(Author author)
		{
			author.Id = Guid.NewGuid().ToString();
			await _bookRepository.AddAuthor(author);
			return true;
		}

		public async Task<bool> DeleteAuthorById(string id)
		{
			return await _bookRepository.DeleteAuthorById(id);
		}

		public async Task<List<Author>> GetAllAuthors()
		{
			return await _bookRepository.GetAllAuthors();
		}

		public async Task<Author?> GetAuthorById(string id)
		{
			return await _bookRepository.GetAuthorById(id);
		}

		public async Task<bool> UpdateAuthor(Author author, string authorId)
		{
			return await _bookRepository.UpdateAuthor(author);
		}
	}
}
