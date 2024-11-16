using Lab_1.Interfaces;
using Lab_1.Models;

namespace Lab_1.Services
{
	public class AuthorService : IAuthorsService
	{
		private List<Author> _authors;

		public AuthorService()
		{
			_authors =
			[
				new Author
				{
					Id = "3FD44B89-F9D3-49BC-ABDF-33DAF9B90870",
					Name = "Yuriy Dold-Mychailyck"
				},
				new Author
				{
					Id = "DCA81070-3A59-4033-8F9A-D8AF18A19C9D",
					Name = "Andrew Troelsen"
				}
			];
		}

		public bool AddAuthor(Author author)
		{
			author.Id = Guid.NewGuid().ToString();
			_authors.Add(author);
			return true;
		}

		public bool DeleteAuthorById(string id)
		{
			var author = GetAuthorById(id);

			if (author != null)
			{
				return _authors.Remove(author);
			}
			return false;
		}

		public List<Author> GetAllAuthors()
		{
			return _authors;
		}

		public Author? GetAuthorById(string id)
		{
			return _authors.FirstOrDefault(a => a.Id == id);
		}

		public bool UpdateAuthor(Author author, string authorId)
		{
			var authorToUpdate = _authors.FirstOrDefault(a => a.Id == authorId);

			if (authorToUpdate != null)
			{
				authorToUpdate.Name = author.Name;
				return true;
			}

			return false;
		}
	}
}
