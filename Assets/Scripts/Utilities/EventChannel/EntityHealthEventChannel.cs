using System;
using UnityEngine;

namespace Game.Utilities.EventChannels {
	[CreateAssetMenu(menuName = "Events/EntityHealthEventChannel")]
	public class EntityHealthEventChannel : EventChannel<HealthUpdate>{

	}
	[Serializable]
	public class HealthUpdate {
		public float MaxHealth;
		public float CurrentHealth;
		public float PreviousHealth;
	}
}

