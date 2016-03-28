using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Automation.Base
{
	public class EnergyCable : EnergyObject
	{
		public override string Name
		{
			get
			{
				return "EnergyCable";
			}
		}

		/// <summary>
		/// Cable can't store any energy
		/// </summary>
		protected override float MaxStoredEnergy
		{
			get
			{
				return 0;
			}
		}
	}
}