using System;
using NDesk.Options;
using System.Collections.Generic;

namespace nurl
{
	public class OptionsManager
	{
		private OptionSet parser;
		private System.IO.TextWriter output;
		public string Url { get; set;}
		public bool ShowHelp { get; set;}

		public OptionsManager (System.IO.TextWriter _output)
		{
			output = _output;
			ShowHelp = false;
			parser = new OptionSet(){
				{ "u|url=", "{URL} to get content from",
              		v => Url = v},
            	{ "h|help",  "show help and exit", 
              		v => ShowHelp = v != null },
			};
		}

		public void parseOption (string[] args)
		{
			List<string> extraOptions;
			try {
				extraOptions = parser.Parse (args);
			} catch (OptionException e) {
				output.Write (e.Message);
				return;
			}

			if (ShowHelp) {
				helpMessage ();
				return;
			}

			if (extraOptions.Count == 1) {
				if(extraOptions[0].Equals("get") && Url.Length != 0)
				{
					var httpHandler = new GetHttpContent(output);
					if(UrlParser.isValidUrl(Url)){
						httpHandler.GetDataAndWrite(Url);
					}
					return;
				}
			}

			helpMessage();
		}
		private void helpMessage(){
			output.Write("this is the help message");
		}
	}
}

