using System;
using NUnit.Framework;

namespace nurl
{
	[TestFixture()]
	public class TestGetHttpContent
	{
		[Test()]
		public void GetHttpIsWorkingOnHugoPoiNet ()
		{
			var o = new System.IO.StringWriter();
			var httpHandler = new GetHttpContent(o);
			httpHandler.GetDataAndWrite("http://blog.hugopoi.net");
			Assert.IsTrue(o.ToString().StartsWith("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">"));
		}
	}
}

