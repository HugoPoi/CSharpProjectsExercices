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
		public string FilePath { get; set;}
		public bool ShowHelp { get; set;}
		public int TestTimes { get; set;}
		public bool TestAvgEnable { get; set;}

		public OptionsManager (System.IO.TextWriter _output)
		{
			output = _output;
			ShowHelp = false;
			parser = new OptionSet(){
				{ "u|url=", "{URL} to get content from",
              		v => Url = v},
				{ "s|save=", "{FILE} for save the content",
              		v => FilePath = v},
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
				if(UrlParser.isValidUrl(Url)){
					if(extraOptions[0].Equals("get"))
					{
						GetHttpContent httpHandler;
						if(FilePath != null)
						{
							var file = new System.IO.StreamWriter(FilePath);
							httpHandler = new GetHttpContent(file);
							httpHandler.GetDataAndWrite(Url);
							file.Close();
						}else{
							httpHandler = new GetHttpContent(output);
							httpHandler.GetDataAndWrite(Url);
						}

						return;
					}
					if(extraOptions[0].Equals("test"))
					{

					}
				}
			}

			helpMessage();
		}
		private void helpMessage(){
			output.Write(@"
nurl is downloader and printer tool for the Web, similar to wget.
2 modes are available for now.
usage :
nurl get -url {URL}
nurl get -url {URL} -save {file}
nurl test -url {URL} -times 5
nurl test -url {URL} -times 5 -avg
");
		}
	}
}

