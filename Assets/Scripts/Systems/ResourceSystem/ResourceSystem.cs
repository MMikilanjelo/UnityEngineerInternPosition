using System.Collections.Generic;
using Game.Utilities.Singletons;
using UnityEngine;
using System.Linq;
using Game.Entities.Enemies;
namespace Game.Systems {
	public class ResourceSystem : PersistentSingleton<ResourceSystem> {
		public List<EnemyData> EnemyDatas { get; private set; }
		private Dictionary<EnemyTypes, EnemyData> enemyDataCollection_;
		protected override void Awake() {
			base.Awake();
			AssembleResources();
			Debug.Log(enemyDataCollection_.Count);
		}
		private void AssembleResources() {
			EnemyDatas = Resources.LoadAll<EnemyData>("Enemies").ToList();

			enemyDataCollection_ = EnemyDatas.ToDictionary(enemy => enemy.Type, enemy => enemy);
		}
		private bool TryGetData<K, T>(K key, Dictionary<K, T> collection, out T data) where T : class {
			return collection.TryGetValue(key, out data);
		}


		public bool TryGetEnemyData(EnemyTypes type, out EnemyData heroData) {
			return TryGetData(type, enemyDataCollection_, out heroData);
		}
	}
}
