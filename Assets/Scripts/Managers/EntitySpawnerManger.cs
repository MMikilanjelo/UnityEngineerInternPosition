using Game.Utilities.Singletons;
using Game.Entities;
using UnityEngine;

namespace Game.Managers {
	public class EntitySpawnerManger : Singleton<EntitySpawnerManger> {
		private EntityFactory entityFactory_;
		protected override void Awake(){
			base.Awake();
			entityFactory_ = new EntityFactory();
		}
		public void SpawnEnemy(EnemyTypes enemyType){
			var enemy = entityFactory_.GetEnemy(enemyType);
		}
		public void SpawnEnemy(){
			Debug.Log("Spawning enemy right now");
		}
	}
}
