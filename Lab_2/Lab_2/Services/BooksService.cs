using Lab_1.Interfaces;
using Lab_1.Models;
using Lab_2.Interfaces;
using Lab_2.Models.DTOs;

namespace Lab_1.Services
{
	public class BooksService : IBooksService
	{
		private readonly IBookRepository _bookRepository;

		public BooksService(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<bool> AddBook(AddBookDTO addBookDto)
		{
			var author = await _bookRepository.GetAuthorById(addBookDto.AuthorId);

			if (author == null)
			{
				return false;
			}

			var book = new Book
			{
				Id = Guid.NewGuid().ToString(),
				Name = addBookDto.Name,
				Author = author,
			};

			try
			{
				await _bookRepository.AddBook(book);
			}
			catch
			{
				return false;
			}

			return true;
		}

		public async Task<bool> DeleteBookById(string id)
		{
			try
			{
				return await _bookRepository.DeleteBookById(id);
			}
			catch
			{
				return false;
			}
		}

		public async Task<List<GetBookDTO>> GetAllBooks()
		{
			return (await _bookRepository.GetAllBooks()).Select(x => x.ToGetBookDTO()).ToList();
		}

		public async Task<GetBookDTO?> GetBookById(string id)
		{
			return (await _bookRepository.GetBookById(id))?.ToGetBookDTO();
		}

		public async Task<bool> UpdateBook(string id, UpdateBookDTO updateBookDto)
		{
			try
			{
				var bookToUpdate = await ConvertToBook(id, updateBookDto);
				return await _bookRepository.UpdateBook(bookToUpdate);
			}
			catch
			{
				return false;
			}
		}

		private async Task<Book> ConvertToBook(string id, UpdateBookDTO updateBookDTO)
		{
			var author = await _bookRepository.GetAuthorById(updateBookDTO.AuthorId);

			return new Book
			{
				Id = id,
				Name = updateBookDTO.Name,
				Author = author
			};
		}
	}
}
