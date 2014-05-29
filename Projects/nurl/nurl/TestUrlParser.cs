using System;
using NUnit.Framework;

namespace nurl
{
	[TestFixture()]
	public class TestUrlParser
	{
		[Test()]
		public void ValidUrls ()
		{
			Assert.IsTrue(UrlParser.isValidUrl("http://google.fr"));
			Assert.IsTrue(UrlParser.isValidUrl("http://google"));
			Assert.IsFalse(UrlParser.isValidUrl("htt://google.fr"));
			Assert.IsFalse(UrlParser.isValidUrl("ftp://google.fr/?yoyo=titi"));
			Assert.IsTrue(UrlParser.isValidUrl("http://localhost:42/toto.txt"));
		}
	}
}

