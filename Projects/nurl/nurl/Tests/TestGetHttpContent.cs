using System;
using NUnit.Framework;

namespace nurl
{
	[TestFixture()]
	public class TestGetHttpContent
	{
		[Test()]
		public void TestCase ()
		{
			var o = new System.IO.StringWriter();
			var httpHandler = new GetHttpContent(o);
			httpHandler.GetDataAndWrite("http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric");
			Assert.IsTrue(o.ToString().StartsWith("{\"coord\":{\"lon\":2.35,\"lat\":48.85}"));
		}
	}
}

