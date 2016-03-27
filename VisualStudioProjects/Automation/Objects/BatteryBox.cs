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
		new public static string DefaultName
		{
			get
			{
				return "BatteryBox";
			}
		}

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
				return base.MaxStoredEnergy;
			}
		}
	}
}