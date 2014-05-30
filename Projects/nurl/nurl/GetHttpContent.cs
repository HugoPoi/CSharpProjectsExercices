using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace nurl
{
	public class GetHttpContent
	{
		private TextWriter output;
		private int bufferSize = 512;
		public List<TimeSpan> Times;
		public TimeSpan AverageTime;

		public GetHttpContent (TextWriter _output)
		{
			output = _output;
		}
		public void GetDataAndWrite (string url)
		{
			var myWebRequest = WebRequest.Create(url); 
			var myWebResponse = myWebRequest.GetResponse(); 

			// Obtain a 'Stream' object associated with the response object.
			var ReceiveStream = myWebResponse.GetResponseStream();
			        	
			var encode = System.Text.Encoding.GetEncoding("utf-8");
			var readStream = new StreamReader( ReceiveStream, encode );

			Char[] read = new Char[bufferSize];
			int count = readStream.Read( read, 0, bufferSize );

			while (count > 0) 
			{
			    var str = new String(read, 0, count);
			    output.Write(str);
			    count = readStream.Read(read, 0, bufferSize);
			}
		    // Release the resources of stream object.
		    readStream.Close();

		    // Release the resources of response object.
		    myWebResponse.Close();
		}

		public void TestTimes (string url, int times)
		{
			Times = new List<TimeSpan>();
			for(int i = 0; i < times; i++)
			{
				var mesureTool = new Stopwatch();
				mesureTool.Start();
				var myWebRequest = WebRequest.Create(url); 
				var myWebResponse = myWebRequest.GetResponse(); 
			    myWebResponse.Close();
				mesureTool.Stop();
				Times.Add(mesureTool.Elapsed);
				output.WriteLine(String.Format("Test {0}. reach {1} in {2} ms", i+1, url, Math.Round(Times[i].TotalMilliseconds,2)));
			}

			AverageTime = new TimeSpan((long)Times.Average(timeSpan => timeSpan.Ticks));


		}
	}
}

