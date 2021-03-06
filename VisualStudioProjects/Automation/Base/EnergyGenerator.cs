﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Automation.Base
{
	public class EnergyGenerator : EnergyObject
	{
		public override string Name
		{
			get
			{
				return "EnergyGenerator";
			}
		}

		/// <summary>
		/// Overwrite this if you want to change the generated energy per second
		/// Default: EnergyConfig.GeneratedEnergyPerSecond_BasicObject * GeneratedEnergyMultiplier
		/// </summary>
		protected virtual float GeneratedEnergyPerSecond
		{
			get
			{
				return EnergyConfig.GetGeneratedEnergyPerSecond_BasicObject() * GeneratedEnergyMultiplier;
			}
		}

		protected float GeneratedEnergyMultiplier = 1f;

		public override void UpdateTick(float delta)
		{
			UpdateEnergyGeneration(delta);
			base.UpdateTick(delta);
			UpdateEnergyDistribution(delta);
		}

		protected virtual void UpdateEnergyGeneration(float delta)
		{
			TryAddEnergy(delta, GeneratedEnergyPerSecond * delta, this);
		}
	}
}