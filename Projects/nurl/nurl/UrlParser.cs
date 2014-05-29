using System;

namespace nurl
{
	public class UrlParser
	{
		public static bool isValidUrl (string url)
		{
			try {
				var parsedUrl = new Uri (url);
				return (parsedUrl.Scheme == Uri.UriSchemeHttp);
			} catch (System.UriFormatException) {
				return false;
			}
		}
	}
}

