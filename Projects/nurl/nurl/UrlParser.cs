using System;

namespace nurl
{
	public class UrlParser
	{
		public static bool isValidUrl (string url)
		{
			var parsedUrl = new Uri(url);
			return (parsedUrl.Scheme == Uri.UriSchemeHttp);
		}
	}
}

