using StardewModdingAPI;
using System.Diagnostics;
using System.Reflection;

namespace Automation
{
	internal class SMAPIMod : Mod
	{
		private AutomationMod mod;

		/// <summary>
		/// SMAPI Entry Point
		/// </summary>
		/// <param name="objects"></param>
		public override void Entry(params object[] objects)
		{
			Init();
		}

		private void Init()
		{
			//SMAPI config will be generated relative to the games installation folder
			mod = new AutomationMod("Mods/");

			//TODO: Add check for incompatible ModAPI version
			FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location);
			string version = fvi.FileVersion;
			Logging.Log(string.Format("SMAPI loaded:{0}", version));
		}
	}
}