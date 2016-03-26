using Newtonsoft.Json;
using System.IO;

namespace Automation
{
	public class ConfigData
	{
		private const string ConfigFileName = "Config.ini";
		public static ConfigData Instance;

		#region Data

		public string Name = "";
		public Base.EnergyConfig EnergyConfig = new Base.EnergyConfig();

		#endregion Data

		/// <summary>
		/// Creates or Loads Config File
		/// </summary>
		/// <param name="relativePath"></param>
		public static void Init(string relativePath)
		{
			Instance = new ConfigData();
			var path = Path.Combine(relativePath, ConfigFileName);

			Logging.Log("Loading Config:{0}", path);

			//Create Config Directory if it does not exist
			Directory.CreateDirectory(Path.GetDirectoryName(path));

			if (!File.Exists(path))
			{
				Instance.Fix(path);
				Logging.Log("Default Config Created:{0}", path);
			}
			else
			{
				Load(path);
				Instance.Fix(path);
				Logging.Log("Config Loaded:{0}", path);
			}
		}

		/// <summary>
		/// Fixes or upgrades config
		/// </summary>
		/// <param name="config"></param>
		private void Fix(string path)
		{
			if (EnergyConfig == null)
				EnergyConfig = new Base.EnergyConfig();

			Save(path);
		}

		private static void Load(string path)
		{
			Instance = JsonConvert.DeserializeObject<ConfigData>(File.ReadAllText(path));
			if (Instance == null)
				Instance = new ConfigData();
		}

		private void Save(string path)
		{
			File.WriteAllText(path, JsonConvert.SerializeObject(this));
		}
	}
}