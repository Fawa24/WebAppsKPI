﻿using Lab_1.Interfaces;
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
		public async Task<ActionResult<List<Author>>> GetAllAuthorsAsync()
		{
			return Ok(await _authorsService.GetAllAuthors());
		}

		/// <summary>
		/// Returns the author with certain ID
		/// </summary>
		/// <param name="id">ID of the author to return</param>
		/// <returns>Author with the specified ID</returns>
		[HttpGet("authors/{id}")]
		public async Task<ActionResult<Author>> GetAuthorByIdAsync(string id)
		{
			var author = await _authorsService.GetAuthorById(id);

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
		public async Task<ActionResult> AddAuthorAsync([FromBody] Author author)
		{
			if (await _authorsService.AddAuthor(author))
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
		public async Task<ActionResult> DeleteAuthorAsync(string id)
		{
			if (await _authorsService.DeleteAuthorById(id))
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
		public async Task<ActionResult> UpdateAuthorAsync([FromBody] Author author, string id)
		{
			if (await _authorsService.UpdateAuthor(author, id))
			{
				return Ok("Updated successfuly");
			}
			return BadRequest($"Invalid input: no author was found");
		}
	}
}
