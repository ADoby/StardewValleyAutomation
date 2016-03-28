using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;

namespace Automation
{
	public class ConfigData
	{
		private const string ConfigFileName = "Config.ini";
		public static ConfigData Instance;

		#region Data

		[DefaultValue("Automation")]
		public string Name;

		public static string GetName()
		{
			return Instance.Name;
		}

		/// <summary>
		/// Custom classes get initialized in ConfigData.Fix method
		/// </summary>
		[DefaultValue(null)]
		public EnergyConfig EnergyConfig;

		public static EnergyConfig GetEnergyConfig()
		{
			return Instance.EnergyConfig;
		}

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
				EnergyConfig = new EnergyConfig();
			if (EnergyConfig.EnergyObjects == null)
				EnergyConfig.EnergyObjects = new EnergyConfig.EnergyObjectConfigs();

			Save(path);
		}

		/// <summary>
		/// Load config from Path into Instance
		/// </summary>
		/// <param name="path"></param>
		public static void Load(string path)
		{
			try
			{
				var serializer = GetSerializer();
				using (StreamReader sr = new StreamReader(path))
				{
					using (JsonReader writer = new JsonTextReader(sr))
					{
						Instance = serializer.Deserialize<ConfigData>(writer);
					}
				}
			}
			catch (System.Exception)
			{
			}

			//Instance = JsonConvert.DeserializeObject<ConfigData>(File.ReadAllText(path));
			if (Instance == null)
				Instance = new ConfigData();
		}

		/// <summary>
		/// Save given Data into given path
		/// </summary>
		/// <param name="path"></param>
		/// <param name="data"></param>
		public void Save(string path)
		{
			try
			{
				var serializer = GetSerializer();
				using (StreamWriter sw = new StreamWriter(path))
				{
					using (JsonWriter writer = new JsonTextWriter(sw))
					{
						serializer.Serialize(writer, this);
					}
				}
			}
			catch (System.Exception)
			{
			}
			//File.WriteAllText(path, JsonConvert.SerializeObject(this));
		}

		private static JsonSerializer GetSerializer()
		{
			var serializer = new JsonSerializer();
			serializer.Formatting = Formatting.Indented;
			serializer.DefaultValueHandling = DefaultValueHandling.Populate;
			serializer.NullValueHandling = NullValueHandling.Include;
			return serializer;
		}
	}
}