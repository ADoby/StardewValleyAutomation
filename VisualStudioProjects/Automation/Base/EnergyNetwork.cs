using Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Base
{
	public class EnergyNetwork
	{
		private List<EnergyObject> Objects = new List<EnergyObject>();

		public EnergyNetwork CreateNetwork(EnergyObject start)
		{
			var network = new EnergyNetwork();

			network.AddObject(start);

			return network;
		}

		/// <summary>
		/// Adds the object and all connected children
		/// </summary>
		/// <param name="target">The target.</param>
		public void AddObject(EnergyObject target)
		{
			if (target == null)
				return;
			if (Objects.Contains(target))
				return;

			//If the target object is connected but not to this network
			//Add all objects from the other network to this one
			if (target.ConnectedNetwork != null && target.ConnectedNetwork != this)
			{
			}

			Objects.Add(target);

			for (int i = 0; i < target.ConnectedObjects.Count; i++)
			{
				AddObject(target.ConnectedObjects[i]);
			}
		}

		public void RemoveObject(EnergyObject target)
		{
			//If an object is removed each side of this objects needs to be calculated into a new network
		}
	}
}