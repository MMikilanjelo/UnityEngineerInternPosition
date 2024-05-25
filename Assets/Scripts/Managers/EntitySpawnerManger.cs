using Game.Utilities.Singletons;
using Game.Entities;
using UnityEngine;
using Game.Systems;
namespace Game.Managers {
	public class EntitySpawnerManger : Singleton<EntitySpawnerManger> {
		private EntityFactory entityFactory_;
		protected override void Awake() {
			base.Awake();
			entityFactory_ = new EntityFactory();
		}
		public void SpawnEnemy(EnemyTypes enemyType , Vector3 position){
			var enemy = entityFactory_.GetEnemy(EnemyTypes.RedEnemy);
			Instantiate(enemy, position, Quaternion.identity);
		}	

	}
}
