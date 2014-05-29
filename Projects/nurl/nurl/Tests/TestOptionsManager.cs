using System;
using NUnit.Framework;

namespace nurl
{
	[TestFixture()]
	public class TestOptionsManager
	{
		[Test()]
		public void helpOption ()
		{
			var o = new System.IO.StringWriter();
			var con = new OptionsManager(o);
			con.parseOption(new []{"--help"});
			Assert.AreEqual("this is the help message", o.ToString());
		}

		[Test]
		public void UrlIsCorrectlyParsed ()
		{
			var o = new System.IO.StringWriter();
			var con = new OptionsManager(o);
			con.parseOption(new []{ "-url", "http://test.fr" });
			Assert.AreEqual("http://test.fr",con.Url);
		}

		[Test]
		public void GetUrlisWorking ()
		{
			var o = new System.IO.StringWriter();
			var con = new OptionsManager(o);
			con.parseOption(new []{ "get","-url", "http://test.fr" });
			Assert.AreEqual("<h1>Hello World</h1>", o.ToString());
		}
	}
}

