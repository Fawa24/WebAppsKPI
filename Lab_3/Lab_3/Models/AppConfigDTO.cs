﻿namespace Lab_3.Models
{
	public class AppConfigDTO
	{
		public AppConfigDTO() { }

		public bool CacheEnabled { get; set; } = false;
		public string AuthorsCacheKey { get; set; } = string.Empty;
		public string BooksCacheKey { get; set; } = string.Empty;
	}
}
