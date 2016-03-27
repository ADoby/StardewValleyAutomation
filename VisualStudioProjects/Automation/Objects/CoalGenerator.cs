using Automation.Base;

namespace Automation.Objects
{
	public class CoalGenerator : EnergyGenerator
	{
		public override string Name
		{
			get
			{
				return "Coal Generator";
			}
		}

		protected override float MaxStoredEnergy
		{
			get
			{
				return EnergyConfig.GetMaxStoredEnergy_CoalGenerator();
			}
		}

		protected override float GeneratedEnergyPerSecond
		{
			get
			{
				return EnergyConfig.GetGeneratedEnergyPerSecond_CoalGenerator() * GeneratedEnergyMultiplier;
			}
		}

		public int FuelCount
		{
			get; set;
		} = 0;

		public float BurnTime
		{
			get; protected set;
		} = 0f;

		protected override void UpdateEnergyGeneration(float delta)
		{
			if (BurnTime > 0)
			{
				base.UpdateEnergyGeneration(delta);
				BurnTime -= delta;
			}
			if (BurnTime <= 0)
			{
				BurnTime = 0;
				//burned out
				TryAddBurnTime();
			}
		}

		protected virtual void TryAddBurnTime()
		{
			if (FuelCount > 0)
			{
				BurnTime += 1f;
				FuelCount--;
			}
		}
	}
}