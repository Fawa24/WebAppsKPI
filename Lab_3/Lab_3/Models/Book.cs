namespace Lab_1.Models
{
	public class Book
	{
		public string Id { get; set; } = string.Empty;
		public string? Name { get; set; }
		public Author? Author { get; set; }
	}
}
