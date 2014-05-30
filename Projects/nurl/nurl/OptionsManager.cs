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
		public bool ShowHelp = false;
		public int TestTimes = 5;
		public bool TestAvgEnable = false;

		public OptionsManager (System.IO.TextWriter _output)
		{
			output = _output;
			parser = new OptionSet(){
				{ "u|url=", "{URL} to get content from",
              		v => Url = v},
				{ "s|save=", "{FILE} for save the content.\n" +
					"",
              		v => FilePath = v},
				{ "t|times=", 
                "the number of {TIMES} to mesure get time.\n" + 
                    "require test mode, this must be an integer.",
              		(int v) => TestTimes = v },
				{ "a|avg",  "show average times.\n" +
					"require test mode",
              		v => TestAvgEnable = v != null },
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
						var httpHandler = new GetHttpContent(output);
						httpHandler.TestTimes(Url, TestTimes);
						if(TestAvgEnable){
							output.WriteLine(String.Format("Average {0} ms", Math.Round(httpHandler.AverageTime.TotalMilliseconds,2)));
						}
						return;
					}
				}
			}

			helpMessage();
		}
		private void helpMessage(){
			output.Write(@"nurl is downloader and printer tool for the Web, similar to wget.
2 modes are available for now.
Usage : nurl {get|test} -url {URL} [OPTIONS]
Options :
");
			parser.WriteOptionDescriptions(output);
			output.Write(
@"
Exemples :
nurl get -url {URL}
nurl get -url {URL} -save {file}
nurl test -url {URL} -times 5
nurl test -url {URL} -times 5 -avg
");
		}
	}
}

