using Lab_3.Services;

namespace Lab_3.Configs
{
	public class AppConfig
	{
		private static AppConfig? Instance { get; set; }
		public static AppConfig Config
		{
			get
			{
				if (Instance == null)
				{
					RegisterConfig();
				}

				return Instance;
			}
		}

		private AppConfig() { }

		public static void RegisterConfig()
		{
			var configDto = new ConfigurationService().GetAppConfig();

			Instance = new AppConfig();
			Instance.CacheEnabled = configDto.CacheEnabled;
			Instance.AuthorsCacheKey = configDto.AuthorsCacheKey;
			Instance.BooksCacheKey = configDto.BooksCacheKey;
		}

		public bool CacheEnabled = false;
		public string AuthorsCacheKey = string.Empty;
		public string BooksCacheKey = string.Empty;
	}
}
