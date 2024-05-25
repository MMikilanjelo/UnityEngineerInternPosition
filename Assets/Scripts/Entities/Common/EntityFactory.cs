using Game.Entities.Enemies;
using Game.Systems;
using UnityEngine;

namespace Game.Entities {
	public class EntityFactory {
		public Enemy GetEnemy(EnemyTypes enemyType){
			if(ResourceSystem.Instance.TryGetEnemyData(enemyType , out EnemyData enemyData)){
				return enemyData.Prefab;
			}
			return null;
		}
	}
}

