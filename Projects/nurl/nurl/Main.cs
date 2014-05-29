using System;

namespace nurl
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var App = new OptionsManager(Console.Out);
			App.parseOption(args);
		}
	}
}
