using System;
using System.Collections.Generic;

namespace Automation.Base
{
	public class EnergyObject
	{
		public static string DefaultName
		{
			get
			{
				return "Base.EnergyObject";
			}
		}

		public virtual string Name
		{
			get
			{
				return "Base.EnergyObject";
			}
		}

		protected float StoredEnergy = 0f;

		public float CurrentStoredEnergy
		{
			get
			{
				return StoredEnergy;
			}
		}

		/// <summary>
		/// Overwrite this if you want to change the maximum stored energy
		/// Default: EnergyConfig.MaxStoredEnergy_BasicObject
		/// </summary>
		protected virtual float MaxStoredEnergy
		{
			get
			{
				return EnergyConfig.GetMaxStoredEnergy_BasicObject();
			}
		}

		/// <summary>
		/// The connected objects
		/// </summary>
		protected List<EnergyObject> ConnectedObjects = new List<EnergyObject>();

		/// <summary>
		/// Adds a connected object.
		/// </summary>
		/// <param name="other">The other.</param>
		public void AddConnectedObject(EnergyObject other)

		{
			ConnectedObjects.Add(other);
		}

		public virtual void UpdateTick()
		{
			UpdateEnergyDistribution();
		}

		protected virtual void UpdateEnergyDistribution()
		{
			for (int i = 0; i < ConnectedObjects.Count; i++)
			{
				if (ConnectedObjects[i] != null)
					TryExchangeEnergy(ConnectedObjects[i], StoredEnergy / ConnectedObjects.Count);
			}
		}

		/// <summary>
		/// Tries to exchange amount to other storage
		/// </summary>
		/// <param name="other"></param>
		/// <param name="amount"></param>
		public void TryExchangeEnergy(EnergyObject other, float amount)
		{
			amount = Math.Min(amount, EnergyConfig.GetMaxEnergyDistributionPerTick());
			if (StoredEnergy > amount)
				StoredEnergy -= other.TryAddEnergy(amount);
		}

		/// <summary>
		/// Tries to add amount to this storage, returns the amount that was actually added
		/// </summary>
		/// <param name="amount"></param>
		/// <returns></returns>
		public float TryAddEnergy(float amount)
		{
			if (amount < 0)
				return 0f;

			var tmpEnergy = StoredEnergy;
			StoredEnergy = Math.Min(StoredEnergy + amount, MaxStoredEnergy);

			return StoredEnergy - tmpEnergy;
		}

		/// <summary>
		/// Tries to remove amount from this storage, returns the amount that was actually removed
		/// </summary>
		/// <param name="wantedAmount"></param>
		/// <returns></returns>
		[Obsolete("Better not use this, shouldn't be needed anyway")]
		public float TryTakeEnergy(float wantedAmount)
		{
			if (wantedAmount > 0)
				return 0f;

			var tmpEnergy = StoredEnergy;
			StoredEnergy = Math.Max(StoredEnergy - wantedAmount, 0);

			return tmpEnergy - StoredEnergy;
		}
	}
}