using Lab_1.Interfaces;
using Lab_1.Models;
using Lab_2.Interfaces;
using Lab_2.Models.DTOs;

namespace Lab_1.Services
{
	public class AuthorService : IAuthorsService
	{
		private readonly IBookRepository _bookRepository;

		public AuthorService(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<bool> AddAuthor(AddAuthorDTO addAuthorDto)
		{
			var author = new Author
			{
				Id = Guid.NewGuid().ToString(),
				Name = addAuthorDto.Name
			};
			try
			{
				await _bookRepository.AddAuthor(author);
			}
			catch
			{
				return false;
			}

			return true;
		}

		public async Task<bool> DeleteAuthorById(string id)
		{
			try
			{
				return await _bookRepository.DeleteAuthorById(id);
			}
			catch
			{
				return false;
			}
		}

		public async Task<List<GetAuthorDTO>> GetAllAuthors()
		{
			return (await _bookRepository.GetAllAuthors()).Select(x => x.ToGetAuthorDTO()).ToList();
		}

		public async Task<GetAuthorDTO?> GetAuthorById(string id)
		{
			return (await _bookRepository.GetAuthorById(id))?.ToGetAuthorDTO();
		}

		public async Task<bool> UpdateAuthor(string id, UpdateAuthorDTO updateAuthorDto)
		{
			var authorToUpdate = ConvertToAuthor(id, updateAuthorDto);
			try
			{
				return await _bookRepository.UpdateAuthor(authorToUpdate);
			}
			catch
			{
				return false;
			}
		}

		private Author ConvertToAuthor(string id, UpdateAuthorDTO updateAuthorDto)
		{
			return new Author
			{
				Id = id,
				Name = updateAuthorDto.Name
			};
		}
	}
}
