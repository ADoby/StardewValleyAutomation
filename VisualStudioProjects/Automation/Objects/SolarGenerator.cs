using Automation.Base;

namespace Automation.Objects
{
	public class SolarGenerator : EnergyGenerator
	{
		public override string Name
		{
			get
			{
				return "Solar Generator";
			}
		}

		protected override float MaxStoredEnergy
		{
			get
			{
				return EnergyConfig.GetMaxStoredEnergy_SolarGenerator();
			}
		}

		protected override float GeneratedEnergyPerSecond
		{
			get
			{
				return EnergyConfig.GetGeneratedEnergyPerSecond_SolarGenerator() * GeneratedEnergyMultiplier;
			}
		}

		public override void Init()
		{
			base.Init();
			EnergyEvents.SunChanged.AddListener(OnSunChanged);
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			EnergyEvents.SunChanged.RemoveListener(OnSunChanged);
		}

		protected virtual void OnSunChanged(EnergyEvents.SunEventArgs args)
		{
			GeneratedEnergyMultiplier = args.SunAmount;
		}
	}
}