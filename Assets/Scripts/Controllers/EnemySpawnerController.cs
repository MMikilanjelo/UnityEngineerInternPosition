using Game.Managers;
using UnityEngine;

namespace Game.Controllers {
	public class EnemySpawnerController : MonoBehaviour {
		[SerializeField] private float minSpawnRadius_ = 10f;
		[SerializeField] private float maxSpawnRadius_ = 20f;
		public void SpawnEnemy() {
			Vector3 playerPosition = GameManager.Instance.Player.transform.position;
			Vector3 randomDirection = Random.insideUnitSphere.normalized * Random.Range(minSpawnRadius_, maxSpawnRadius_);
			
			randomDirection.y = playerPosition.y;//Need this to ensure enemies will spawn in same lvl as player;
			
			Vector3 spawnPosition = new Vector3(playerPosition.x + randomDirection.x, playerPosition.y + randomDirection.y, playerPosition.z);
			
			Collider[] colliders = Physics.OverlapSphere(spawnPosition, 1f);
			if (colliders.Length == 0) {
				EntitySpawnerManger.Instance.SpawnEnemy(EnemyTypes.RedEnemy , spawnPosition);
			}
			else {
				Debug.Log("Spawn position occupied. Trying again...");
				SpawnEnemy();
			}
		}
	}
}

