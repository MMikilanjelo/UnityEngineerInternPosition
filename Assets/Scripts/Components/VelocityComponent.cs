
using UnityEngine;
using Game.Entities;
namespace Game.Components {
	public class VelocityComponent {
		private float accelerationCoefficientMultiplier_ { get; set; } = 1f;
		private Vector3 velocity_ { get; set; }
		private float maxSpeed_ = 1.0f;
		private float accelerationCoefficient_ = 2.0f;

		public VelocityComponent(float maxSpeed, float accelerationCoefficient) {
			maxSpeed_ = maxSpeed;
			accelerationCoefficient_ = accelerationCoefficient;
		}

		private void AccelerateToVelocity(Vector3 velocity) {
			velocity_ = Vector3.Lerp(velocity_, velocity, 1f - Mathf.Exp(-accelerationCoefficient_ * accelerationCoefficientMultiplier_ * Time.deltaTime));
		}

		private void AccelerateInDirection(Vector3 direction) {
			AccelerateToVelocity(direction * maxSpeed_);
		}

		public void Move(Vector3 direction, GameObject entity) {
			AccelerateInDirection(direction);
			entity.transform.position += velocity_ * Time.deltaTime;
		}
	}


}
