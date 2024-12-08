using System.ComponentModel.DataAnnotations;

namespace Lab_2.Models.DTOs
{
	public class AddAuthorDTO
	{
		[MaxLength(30, ErrorMessage = "Author name cannot be longer than 30 characters")]
		public string Name { get; set; } = string.Empty;
	}
}
