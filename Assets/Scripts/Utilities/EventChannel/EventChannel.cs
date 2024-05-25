using System;
using UnityEngine;
using System.Collections.Generic;
namespace Game.Utilities.EventChannels {
	public abstract class EventChannel<T> : ScriptableObject {
		readonly private HashSet<EventListener<T>> observers_ = new();

		public void Invoke(T value) {
			foreach (var observer in observers_) {
				observer.Raise(value);
			}
		}

		public void Register(EventListener<T> observer) => observers_.Add(observer);
		public void Deregister(EventListener<T> observer) => observers_.Remove(observer);
	}

	public readonly struct Empty { }

	[CreateAssetMenu(menuName = "Events/EventChannel")]
	public class EventChannel : EventChannel<Empty> { }
}
