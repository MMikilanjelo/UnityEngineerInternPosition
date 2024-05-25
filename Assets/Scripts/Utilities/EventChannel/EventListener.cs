using UnityEngine;
using UnityEngine.Events;

namespace Game.Utilities.EventChannels {
	public abstract class EventListener<T> : MonoBehaviour {
		[SerializeField] public EventChannel<T> EventChannel; // Backing field for EventChannel
		[SerializeField] public UnityEvent<T> UnityEvent; // Backing field for UnityEvent

		protected void Awake() {
			EventChannel.Register(this);
		}

		protected void OnDestroy() {
			EventChannel.Deregister(this);
		}

		public void Raise(T value) {
			UnityEvent?.Invoke(value);
		}
	}

	public class EventListener : EventListener<Empty> { }
}
