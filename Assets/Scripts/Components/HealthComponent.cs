using UnityEngine;
using System;
using Game.Utilities.EventChannels;

namespace Game.Entities.Components {
	public class HealthComponent : MonoBehaviour {
		[SerializeField] private float maxHealth_ = 15.0f;
		[SerializeField] private EntityHealthEventChannel entityHealthChannel_;
		private float currentHealth_ = 15.0f;
		private bool hasDied_;
		
		public event Action<HealthUpdate> HealthChanged = delegate { };
		public event Action Died = delegate { };

		public bool IsDamaged => currentHealth_ < maxHealth_;
		public bool HasHealthRemaining => !Mathf.Approximately(currentHealth_, 0f);
		public bool CanAcceptDamage { get; set; } = true;
		

		private void Awake(){
			InitializeHealth(maxHealth_);
		}
		private void Start(){
			PublishHealth(new HealthUpdate{
				CurrentHealth = currentHealth_,
				MaxHealth = maxHealth_,
				PreviousHealth = currentHealth_,
			});
		}
		public void InitializeHealth(float maxHealth_) {
			MaxHealth = maxHealth_;
			CurrentHealth = MaxHealth;
		}
		public float MaxHealth {
			get => maxHealth_;
			private set {
				maxHealth_ = value;
				if (currentHealth_ > maxHealth_) {
					currentHealth_ = maxHealth_;
				}
			}
		}
		public float CurrentHealth {
			get => currentHealth_;
			private set {
				var previousHealth = currentHealth_;
				currentHealth_ = Mathf.Clamp(value, 0, MaxHealth);
				var healthUpdate = new HealthUpdate {
					CurrentHealth = currentHealth_,
					MaxHealth = maxHealth_,
					PreviousHealth = previousHealth,
				};
				
				if(entityHealthChannel_ != null){
					PublishHealth(healthUpdate);
				}
				
				HealthChanged?.Invoke(healthUpdate);
				if (!HasHealthRemaining && !hasDied_) {
					hasDied_ = true;
					Died?.Invoke();
				}
			}
		}
		public void DealDamage(float damage) {
			if (CanAcceptDamage) {
				CurrentHealth -= damage;

			}
		}
		private void PublishHealth(HealthUpdate healthUpdate){
			if(entityHealthChannel_ != null){
				entityHealthChannel_.Invoke(healthUpdate);
			}
		}



	}
	
}