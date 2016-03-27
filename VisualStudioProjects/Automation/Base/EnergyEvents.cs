using System;

namespace Automation.Base
{
	public class EnergyEvents
	{
		#region WIND

		public struct WindEventArgs
		{
			public float WindSpeed;
		}

		public static EnergyEvent<WindEventArgs> WindChanged;

		#endregion WIND

		#region SUN

		public struct SunEventArgs
		{
			public float SunAmount;
		}

		public static EnergyEvent<SunEventArgs> SunChanged;

		#endregion SUN
	}

	public class EnergyEvent<T>
	{
		private Action<T> Callback = null;

		public void AddListener(Action<T> callback)
		{
			Callback -= callback;
			Callback += callback;
		}

		public void RemoveListener(Action<T> callback)
		{
			Callback -= callback;
		}

		public void Dispatch(T value)
		{
			if (Callback != null)
				Callback.Invoke(value);
		}
	}
}