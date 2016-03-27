using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Objects
{
	/// <summary>
	/// Simple Battery Box which can store a customizable amount of energy
	/// </summary>
	public class BatteryBox : Base.EnergyObject
	{
		public override string Name
		{
			get
			{
				return "BatteryBox";
			}
		}

		protected override float MaxStoredEnergy
		{
			get
			{
				return EnergyConfig.GetMaxStoredEnergy_BatteryBox();
			}
		}
	}
}