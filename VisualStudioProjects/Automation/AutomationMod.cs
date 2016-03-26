namespace Automation
{
	public class AutomationMod
	{
		public AutomationMod(string configPath = "")
		{
			Logging.SetLoggingPrefix("[Automation]:");
			ConfigData.Init(System.IO.Path.Combine(configPath, "Automation"));
			Init();
		}

		protected virtual void Init()
		{
		}
	}
}