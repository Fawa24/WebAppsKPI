using Lab_1.Interfaces;
using Lab_1.Models;

namespace Lab_1.Services
{
	public class BooksService : IBooksService
	{
		private List<Book> _books;

		public BooksService()
		{
			_books =
			[
				new Book
				{
					Id = "2287C0AD-F383-4486-81B8-B3DC37C21A59",
					Name = "And the one in the field warrior",
					Author = new Author
					{
						Id = "3FD44B89-F9D3-49BC-ABDF-33DAF9B90870",
						Name = "Yuriy Dold-Mychailyck"
					}
				},
				new Book
				{
					Id = "329B3705-41BD-4731-ABD4-51243CA4FF9C",
					Name = "Pro C# 10 with .NET 6",
					Author = new Author
					{
						Id = "DCA81070-3A59-4033-8F9A-D8AF18A19C9D",
						Name = "Andrew Troelsen"
					}
				},
			];
		}

		public bool AddBook(Book book)
		{
			_books.Add(book);
			return true;
		}

		public bool DeleteBookById(string id)
		{
			var book = GetBookById(id);

			if (book != null)
			{
				return _books.Remove(book);
			}
			return false;
		}

		public List<Book> GetAllBooks()
		{
			return _books;
		}

		public Book? GetBookById(string id)
		{
			return _books.FirstOrDefault(a => a.Id == id);
		}

		public bool UpdateBook(Book book, string bookId)
		{
			var bookToUpdate = _books.FirstOrDefault(b => b.Id == bookId);

			if (bookToUpdate != null)
			{
				bookToUpdate.Name = book.Name;
				bookToUpdate.Author = book.Author;
				return true;
			}

			return false;
		}
	}
}
