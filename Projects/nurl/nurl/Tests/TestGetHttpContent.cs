using System;
using NUnit.Framework;
using System.IO;

namespace nurl
{
	[TestFixture()]
	public class TestGetHttpContent
	{
		[Test()]
		public void GetHttpIsWorkingOnHugoPoiNet ()
		{
			var output = new StringWriter();
			var httpHandler = new GetHttpContent(output);
			httpHandler.GetDataAndWrite("http://blog.hugopoi.net");
			Assert.IsTrue(output.ToString().StartsWith("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">"));
		}
		[Test]
		public void TestHttpTimes ()
		{
			var output = new StringWriter();
			var httpHandler = new GetHttpContent(output);
			httpHandler.TestTimes("http://blog.hugopoi.net",5);
			Assert.IsTrue(httpHandler.Times.Count == 5);
		}
		[Test]
		public void AverageTime ()
		{
			var output = new StringWriter ();
			var httpHandler = new GetHttpContent (output);
			httpHandler.TestTimes ("http://blog.hugopoi.net", 5);
			var total = new TimeSpan(0);
			foreach (TimeSpan t in httpHandler.Times) {
				total = total.Add(t);
			}
			Assert.AreEqual(Math.Round(total.TotalMilliseconds/5), System.Math.Round(httpHandler.AverageTime.TotalMilliseconds));
		}
	}
}

