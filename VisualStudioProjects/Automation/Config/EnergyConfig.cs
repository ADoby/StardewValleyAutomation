using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation
{
	[System.Serializable]
	public class EnergyConfig
	{
		[System.Serializable]
		public class EnergyObjectConfigs
		{
			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
			public float BaseObject_MaxStoredEnergy = 1000f;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
			public float BatteryBox_MaxStoredEnergy = 1000f;
		}

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public float MaxEnergyDistributionPerTick = 256f;

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public EnergyObjectConfigs EnergyObjects = null;

		public static float GetMaxEnergyDistributionPerTick()
		{
			return ConfigData.Instance.EnergyConfig.MaxEnergyDistributionPerTick;
		}

		public static EnergyObjectConfigs GetEnergyObjects()
		{
			return ConfigData.Instance.EnergyConfig.EnergyObjects;
		}

		public static float GetMaxStoredEnergy_BasicObject()
		{
			return GetEnergyObjects().BaseObject_MaxStoredEnergy;
		}

		public static float GetMaxStoredEnergy_BatteryBox()
		{
			return GetEnergyObjects().BatteryBox_MaxStoredEnergy;
		}
	}
}