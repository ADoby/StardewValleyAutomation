using Storm.ExternalEvent;
using Storm.StardewValley;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Automation
{
	[Mod]
	internal class STORMMod : DiskResource
	{
		private AutomationMod mod;

		private void Init()
		{
			Logging.OverwriteLogHandler(Log);

			mod = new AutomationMod(StormApi.ModsPath);

			FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location);
			string version = fvi.FileVersion;
			Logging.Log(string.Format("STORM loaded:{0}", version));
		}

		private void Log(string message)
		{
			Storm.Logging.Logs(message);
		}
		
	}
}