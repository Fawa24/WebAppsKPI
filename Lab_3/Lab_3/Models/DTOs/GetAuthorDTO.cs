using Lab_1.Models;

namespace Lab_2.Models.DTOs
{
	public class GetAuthorDTO
	{
		public string Id { get; set; } = string.Empty;
		public string? Name { get; set; }
	}

	public static class AuthorExtension
	{
		public static GetAuthorDTO ToGetAuthorDTO(this Author author)
		{
			return new GetAuthorDTO
			{
				Id = author.Id,
				Name = author.Name
			};
		}
	}
}
