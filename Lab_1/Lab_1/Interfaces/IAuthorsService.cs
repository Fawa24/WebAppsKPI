using Lab_1.Models;

namespace Lab_1.Interfaces
{
	public interface IAuthorsService
	{
		public List<Author> GetAllAuthors();
		public Author? GetAuthorById(string id);
		public bool DeleteAuthorById(string id);
		public bool AddAuthor(Author author);
		public bool UpdateAuthor(Author author, string authorId);
	}
}
