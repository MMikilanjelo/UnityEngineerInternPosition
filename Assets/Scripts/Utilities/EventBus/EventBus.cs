using System.Collections.Generic;
using UnityEngine;
namespace Game.Utilities.EventBus {

	public static class EventBus<T> where T : IEvent {
		static readonly HashSet<IEventBinding<T>> bindings_ = new HashSet<IEventBinding<T>>();

		public static void Register(EventBinding<T> binding) => bindings_.Add(binding);
		public static void Deregister(EventBinding<T> binding) => bindings_.Remove(binding);

		public static void Raise(T @event) {
			foreach (var binding in bindings_) {
				binding.OnEvent.Invoke(@event);
				binding.OnEventNoArgs.Invoke();
			}
		}

		static void Clear() {
			Debug.Log($"Clearing {typeof(T).Name} bindings_");
			bindings_.Clear();
		}
	}
}