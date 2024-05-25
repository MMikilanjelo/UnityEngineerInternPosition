using Game.Components;
using Game.Entities.Components;
using UnityEngine;
using Game.Managers;
namespace Game.Enemies.Projectiles {
	public class RedEnemyProjectile : MonoBehaviour {
		[SerializeField] private float speed_ = 2.0f;
		[SerializeField] private float accelerationCoefficient_ = 2.0f;
		[SerializeField] private float lifeTime_ = 5.0f;
		[SerializeField] private int damage_ = 1;
		private VelocityComponent velocityComponent_;
		private Vector3 direction_;
		private void Awake(){
			velocityComponent_ = new VelocityComponent(speed_ ,accelerationCoefficient_ );
		}
		private void Start() {
			direction_ = (GameManager.Instance.Player.transform.position  - transform.position).normalized;
			Destroy(gameObject, lifeTime_);
		}
		private void Update(){
			velocityComponent_.Move(direction_ , this.gameObject);
		}

		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag("Player")) {
				HandlePlayerCollision(other);
			}
		}

		private void HandlePlayerCollision(Collider player) {
			HealthComponent playerHealth = player.GetComponent<HealthComponent>();
			if (playerHealth != null) {
				playerHealth.DealDamage(damage_);
			}
			Destroy(gameObject);
		}
	}
}
