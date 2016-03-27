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
			//Base
			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
			public float BaseObject_MaxStoredEnergy = 1000f;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
			public float BasicObject_GeneratedEnergyPerSecond = 16f;

			//Battery Box
			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
			public float BatteryBox_MaxStoredEnergy = 1000f;

			//Coal Generator
			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
			public float CoalGenerator_MaxStoredEnergy = 1000f;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
			public float CoalGenerator_GeneratedEnergyPerSecond = 16f;

			//Solar Generator
			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
			public float SolarGenerator_MaxStoredEnergy = 1000f;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
			public float SolarGenerator_GeneratedEnergyPerSecond = 16f;
		}

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public float MaxEnergyDistributionPerTick = 256f;

		public static float GetMaxEnergyDistributionPerTick()
		{
			return ConfigData.Instance.EnergyConfig.MaxEnergyDistributionPerTick;
		}

		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public EnergyObjectConfigs EnergyObjects = null;

		public static EnergyObjectConfigs GetEnergyObjects()
		{
			return ConfigData.Instance.EnergyConfig.EnergyObjects;
		}

		#region BASE

		//Base Storage
		public static float GetMaxStoredEnergy_BasicObject()
		{
			return GetEnergyObjects().BaseObject_MaxStoredEnergy;
		}

		//Base Generator
		public static float GetGeneratedEnergyPerSecond_BasicObject()
		{
			return GetEnergyObjects().BasicObject_GeneratedEnergyPerSecond;
		}

		#endregion BASE

		#region BatteryBox

		public static float GetMaxStoredEnergy_BatteryBox()
		{
			return GetEnergyObjects().BatteryBox_MaxStoredEnergy;
		}

		#endregion BatteryBox

		#region COAL_GENERATOR

		public static float GetMaxStoredEnergy_CoalGenerator()
		{
			return GetEnergyObjects().CoalGenerator_MaxStoredEnergy;
		}

		public static float GetGeneratedEnergyPerSecond_CoalGenerator()
		{
			return GetEnergyObjects().CoalGenerator_GeneratedEnergyPerSecond;
		}

		#endregion COAL_GENERATOR

		#region SOLAR_GENERATOR

		public static float GetMaxStoredEnergy_SolarGenerator()
		{
			return GetEnergyObjects().SolarGenerator_MaxStoredEnergy;
		}

		public static float GetGeneratedEnergyPerSecond_SolarGenerator()
		{
			return GetEnergyObjects().SolarGenerator_GeneratedEnergyPerSecond;
		}

		#endregion SOLAR_GENERATOR
	}
}