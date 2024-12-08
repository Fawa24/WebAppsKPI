using Lab_1.Interfaces;
using Lab_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1.Controllers
{
	public class BooksController : ControllerBase
	{
		private readonly IBooksService _booksService;

		public BooksController(IBooksService booksService)
		{
			_booksService = booksService;
		}

		/// <summary>
		/// Returns all the existing books
		/// </summary>
		/// <returns>All the books from the storage</returns>
		[HttpGet("books/")]
		public async Task<ActionResult<List<Book>>> GetAllBooksAsync()
		{
			return Ok(await _booksService.GetAllBooks());
		}

		/// <summary>
		/// Returns the book with certain ID
		/// </summary>
		/// <param name="id">ID of the book to return</param>
		/// <returns>Book with the specified ID</returns>
		[HttpGet("books/{id}")]
		public async Task<ActionResult<Book>> GetBookById(string id)
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
		/// <param name="author">Book to add</param>
		/// <returns>Nothing</returns>
		[HttpPost("books/")]
		public async Task<ActionResult> AddBook([FromBody] Book book)
		{
			if (await _booksService.AddBook(book))
			{
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
				return Ok("Deleted successfully");
			}

			return BadRequest($"Invalid input: no book has {id} id");
		}

		/// <summary>
		/// Updates book's info
		/// </summary>
		/// <param name="book">New book's fields</param>
		/// <param name="id">ID of the book to update</param>
		/// <returns>Nothing</returns>
		[HttpPut("books/{id}")]
		public async Task<ActionResult> UpdateBookAsync([FromBody] Book book, string id)
		{
			if (await _booksService.UpdateBook(book, id))
			{
				return Ok("Updated successfuly");
			}
			return BadRequest("Something went wrong");
		}
	}
}
