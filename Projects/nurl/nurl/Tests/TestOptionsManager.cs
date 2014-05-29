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
			con.parseOption(new []{ "get","-url", "http://blog.hugopoi.net" });
			Assert.IsTrue(o.ToString().StartsWith("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">"));
		}
		[Test]
		public void GetUrlToFile ()
		{
			var o = new System.IO.StringWriter();
			var con = new OptionsManager(o);
			con.parseOption(new []{ "get","-url", "http://blog.hugopoi.net", "-save", "test.txt"});
			Assert.IsTrue((new System.IO.StreamReader("test.txt")).ReadToEnd().StartsWith("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">"));
			(new System.IO.FileInfo("test.txt")).Delete();
			//Assert.IsFalse((new System.IO.FileInfo("test.txt")).Exists());
		}
	}
}

