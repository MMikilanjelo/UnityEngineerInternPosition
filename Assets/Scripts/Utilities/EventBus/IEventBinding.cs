using System;

namespace Game.Utilities.EventBus {
	public interface IEventBinding<T> {
		public Action<T> OnEvent { get; set; }
		public Action OnEventNoArgs { get; set; }
	}

	public class EventBinding<T> : IEventBinding<T> where T : IEvent {
		Action<T> onEvent_ = _ => { };
		Action onEventNoArgs_ = () => { };

		Action<T> IEventBinding<T>.OnEvent {
			get => onEvent_;
			set => onEvent_ = value;
		}

		Action IEventBinding<T>.OnEventNoArgs {
			get => onEventNoArgs_;
			set => onEventNoArgs_ = value;
		}

		public EventBinding(Action<T> onEvent_) => this.onEvent_ = onEvent_;
		public EventBinding(Action onEventNoArgs_) => this.onEventNoArgs_ = onEventNoArgs_;

		public void Add(Action onEvent_) => onEventNoArgs_ += onEvent_;
		public void Remove(Action onEvent_) => onEventNoArgs_ -= onEvent_;

		public void Add(Action<T> onEvent_) => this.onEvent_ += onEvent_;
		public void Remove(Action<T> onEvent_) => this.onEvent_ -= onEvent_;
	}
}
