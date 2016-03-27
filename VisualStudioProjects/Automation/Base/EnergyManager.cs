using System.Collections.Generic;

namespace Automation.Base
{
	public class EnergyManager
	{
		public List<EnergyObject> ManagedObjects = new List<EnergyObject>();

		public void AddManagedObject(EnergyObject newObject)
		{
			if (ManagedObjects.Contains(newObject))
				return;
			ManagedObjects.Add(newObject);
		}

		public void UpdateTick(float delta)
		{
			UpdateManagedObjects(delta);
		}

		private void UpdateManagedObjects(float delta)
		{
			for (int i = 0; i < ManagedObjects.Count; i++)
			{
				if (ManagedObjects[i] != null)
					ManagedObjects[i].UpdateTick(delta);
			}
		}
	}
}