using Lab_1.Interfaces;
using Lab_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1.Controllers
{
	public class AuthorsController : ControllerBase
	{
		private readonly IAuthorsService _authorsService;

		public AuthorsController(IAuthorsService authorsService)
		{
			_authorsService = authorsService;
		}

		/// <summary>
		/// Returns all the existing authors
		/// </summary>
		/// <returns>All the authors from the storage</returns>
		[HttpGet("authors/")]
		public ActionResult<List<Author>> GetAllAuthors()
		{
			return Ok(_authorsService.GetAllAuthors());
		}

		/// <summary>
		/// Returns the author with certain ID
		/// </summary>
		/// <param name="id">ID of the author to return</param>
		/// <returns>Author with the specified ID</returns>
		[HttpGet("authors/{id}")]
		public ActionResult<Author> GetAuthorById(string id)
		{
			var author = _authorsService.GetAuthorById(id);

			if (author == null)
			{
				return BadRequest($"Invalid input: no author has {id} id");
			}

			return Ok(author);
		}

		/// <summary>
		/// Adds new author to the storage
		/// </summary>
		/// <param name="author">Author to add</param>
		/// <returns>Nothing</returns>
		[HttpPost("authors/")]
		public ActionResult AddAuthor([FromBody] Author author)
		{
			if (_authorsService.AddAuthor(author))
			{
				return Ok("Added successfully");
			}

			return BadRequest("Something went wrong");
		}

		/// <summary>
		/// Deletes existing author by specified ID
		/// </summary>
		/// <param name="id">ID of the author to delete</param>
		/// <returns>Nothing</returns>
		[HttpDelete("authors/{id}")]
		public ActionResult DeleteAuthor(string id)
		{
			if (_authorsService.DeleteAuthorById(id))
			{
				return Ok("Deleted successfully");
			}

			return BadRequest($"Invalid input: no author was found");
		}

		/// <summary>
		/// Updates author's info
		/// </summary>
		/// <param name="author">New author's fileds</param>
		/// <param name="id">ID of the author to update</param>
		/// <returns>Nothing</returns>
		[HttpPut("authors/{id}")]
		public ActionResult UpdateAuthor([FromBody] Author author, string id)
		{
			if (_authorsService.UpdateAuthor(author, id))
			{
				return Ok("Updated successfuly");
			}
			return BadRequest($"Invalid input: no author was found");
		}
	}
}
