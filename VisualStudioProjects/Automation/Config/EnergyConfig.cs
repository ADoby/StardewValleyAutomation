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
			[DefaultValue(1000f)]
			public float BaseObject_MaxStoredEnergy;

			[DefaultValue(16f)]
			public float BasicObject_GeneratedEnergyPerSecond;

			//Battery Box
			[DefaultValue(1000f)]
			public float BatteryBox_MaxStoredEnergy;

			//Coal Generator
			[DefaultValue(1000f)]
			public float CoalGenerator_MaxStoredEnergy;

			[DefaultValue(16f)]
			public float CoalGenerator_GeneratedEnergyPerSecond;

			//Solar Generator
			[DefaultValue(1000f)]
			public float SolarGenerator_MaxStoredEnergy;

			[DefaultValue(16f)]
			public float SolarGenerator_GeneratedEnergyPerSecond;
		}

		[DefaultValue(256)]
		public float MaxEnergyDistributionPerTick;

		public static float GetMaxEnergyDistributionPerTick()
		{
			return ConfigData.Instance.EnergyConfig.MaxEnergyDistributionPerTick;
		}

		[DefaultValue(null)]
		public EnergyObjectConfigs EnergyObjects;

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