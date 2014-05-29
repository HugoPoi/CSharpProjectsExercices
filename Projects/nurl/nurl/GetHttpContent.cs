using System;
using System.Net;
using System.IO;

namespace nurl
{
	public class GetHttpContent
	{
		private System.IO.TextWriter output;
		private int bufferSize = 512;
		public GetHttpContent (System.IO.TextWriter _output)
		{
			output = _output;
		}
		public void GetDataAndWrite (string url)
		{
			WebRequest myWebRequest = WebRequest.Create(url); 
			WebResponse myWebResponse = myWebRequest.GetResponse(); 

			// Obtain a 'Stream' object associated with the response object.
			var ReceiveStream = myWebResponse.GetResponseStream();
			        	
			var encode = System.Text.Encoding.GetEncoding("utf-8");
			StreamReader readStream = new StreamReader( ReceiveStream, encode );

			Char[] read = new Char[512];
			int count = readStream.Read( read, 0, bufferSize );

			while (count > 0) 
			{
			    String str = new String(read, 0, count);
			    output.Write(str);
			    count = readStream.Read(read, 0, bufferSize);
			}
		     // Release the resources of stream object.
		     readStream.Close();

		     // Release the resources of response object.
		     myWebResponse.Close(); 
		}
	}
}

