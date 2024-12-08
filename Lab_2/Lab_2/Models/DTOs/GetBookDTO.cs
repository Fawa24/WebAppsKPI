using Lab_1.Models;

namespace Lab_2.Models.DTOs
{
	public class GetBookDTO
	{
		public string Id { get; set; } = string.Empty;
		public string? Name { get; set; }
		public Author? Author { get; set; }
	}

	public static class BookExtension
	{
		public static GetBookDTO ToGetBookDTO(this Book book)
		{
			return new GetBookDTO
			{
				Id = book.Id,
				Author = book.Author,
				Name = book.Name
			};
		}
	}
}
