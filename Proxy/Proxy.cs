using System.Collections.Generic;

namespace Patterns.Proxy
{
	public class Page
	{

	}

	public interface IBrowser
	{
		Page LoadPage(string url);
	}

	public class Browser: IBrowser
	{
		public Browser()
		{
			// uses RAM
		}

		public Page LoadPage(string url)
		{
			return new Page();
		}
	}

	public class ProxyBrowser: IBrowser
	{
		private Browser browser;
		private Dictionary<string, Page> cache;

		public ProxyBrowser()
		{
			// lazy initializating
		}

		public Page LoadPage(string url)
		{
			if (cache == null)
			{
				cache = new Dictionary<string, Page>();
			}

			if (browser == null)
			{
				browser = new Browser();
			}

			if (!cache.ContainsKey(url))
			{
				cache[url] = browser.LoadPage(url);
			}
			return cache[url];
		}
	}

	public class Application
	{
		private IBrowser browser;
		public Application(IBrowser browser)
		{
			this.browser = browser;
		}

		public void OnSearchButton(string url)
		{
			browser.LoadPage(url);
		}
	}
}