using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BosKov
{
    public class Enemy1Spawner : MonoBehaviour
    {
        public float yPos = 0;
        public bool spawnAnEnemyDebug = false;

        [SerializeField] GameObject whatToSpawn = default;

        private GameObject enemyClone;

        private void Update()
        {
            if (spawnAnEnemyDebug == true)
            {
                SpawnEnemy();
                spawnAnEnemyDebug = false;
            }
        }

        public void SpawnEnemy()
        {
            enemyClone = Instantiate(whatToSpawn, transform);
            enemyClone.GetComponent<Enemy1Behaviour>().isFired = true;
        }
    }
}