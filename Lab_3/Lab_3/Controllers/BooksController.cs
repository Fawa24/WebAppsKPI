using Lab_1.Interfaces;
using Lab_2.Filters;
using Lab_2.Models.DTOs;
using Lab_3.Configs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Lab_1.Controllers
{
	public class BooksController : ControllerBase
	{
		private readonly IMemoryCache _cache;
		private readonly IBooksService _booksService;

		public BooksController(IMemoryCache cache
			, IBooksService booksService)
		{
			_cache = cache;
			_booksService = booksService;
		}

		/// <summary>
		/// Returns all the existing books
		/// </summary>
		/// <returns>All the books from the storage</returns>
		[HttpGet("books/")]
		public async Task<ActionResult<List<GetBookDTO>>> GetAllBooksAsync()
		{
			if (_cache.TryGetValue(AppConfig.Config.BooksCacheKey, out List<GetBookDTO> books))
			{
				return Ok(books);
			}

			books = await _booksService.GetAllBooks();
			if (AppConfig.Config.CacheEnabled)
			{
				_cache.Set(AppConfig.Config.BooksCacheKey, books, TimeSpan.FromMinutes(5));
			}

			return Ok(books);
		}

		/// <summary>
		/// Returns the book with certain ID
		/// </summary>
		/// <param name="id">ID of the book to return</param>
		/// <returns>Book with the specified ID</returns>
		[HttpGet("books/{id}")]
		public async Task<ActionResult<GetBookDTO>> GetBookById(string id)
		{
			var book = await _booksService.GetBookById(id);

			if (book == null)
			{
				return BadRequest($"Invalid input: no book has {id} id");
			}

			return Ok(book);
		}

		/// <summary>
		/// Adds new book to the storage
		/// </summary>
		/// <param name="book">Book to add</param>
		/// <returns>Nothing</returns>
		[HttpPost("books/")]
		[ValidationFilter]
		public async Task<ActionResult> AddBook([FromBody] AddBookDTO book)
		{
			if (await _booksService.AddBook(book))
			{
				_cache.Remove(AppConfig.Config.BooksCacheKey);
				return Ok("Added successfully");
			}

			return BadRequest("Something went wrong");
		}

		/// <summary>
		/// Deletes existing book by specified ID
		/// </summary>
		/// <param name="id">ID of the book to delete</param>s
		/// <returns>Nothing</returns>
		[HttpDelete("books/{id}")]
		public async Task<ActionResult> DeleteBookById(string id)
		{
			if (await _booksService.DeleteBookById(id))
			{
				_cache.Remove(AppConfig.Config.BooksCacheKey);
				return Ok("Deleted successfully");
			}

			return BadRequest($"Invalid input: no book has {id} id");
		}

		/// <summary>
		/// Updates book's info
		/// </summary>
		/// <param name="book">New book's fields</param>
		/// <returns>Nothing</returns>
		[HttpPut("books/{id}")]
		[ValidationFilter]
		public async Task<ActionResult> UpdateBookAsync([FromBody] UpdateBookDTO book, string id)
		{
			if (await _booksService.UpdateBook(id, book))
			{
				_cache.Remove(AppConfig.Config.BooksCacheKey);
				return Ok("Updated successfuly");
			}
			return BadRequest("Something went wrong");
		}
	}
}
