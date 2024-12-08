using System.ComponentModel.DataAnnotations;

namespace Lab_2.Models.DTOs
{
	public class UpdateBookDTO
	{
		[MaxLength(30, ErrorMessage = "Book name cannot be longer than 30 characters")]
		public string? Name { get; set; }

		[Length(36, 36, ErrorMessage = "Invalid author's Id format")]
		public string AuthorId { get; set; } = string.Empty;
	}
}