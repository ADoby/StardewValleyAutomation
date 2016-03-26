using StardewModdingAPI;
using System.Diagnostics;
using System.Reflection;

namespace Automation
{
	internal class SMAPIMod : Mod
	{
		private AutomationMod mod;

		public override void Entry(params object[] objects)
		{
			Init();
		}

		private void Init()
		{
			mod = new AutomationMod("Mods/");

			FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location);
			string version = fvi.FileVersion;
			Logging.Log(string.Format("SMAPI loaded:{0}", version));
		}
	}
}