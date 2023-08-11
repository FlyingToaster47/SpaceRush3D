using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] private Transform[] obstaclePrefabs;
    [SerializeField] private Transform player;
    [Range(1, 6)]
    [SerializeField] private int noOfObstacles = 4;
    [SerializeField] private int spreadRange = 500;


    private void Start() {
        SpawnObstacle();
    }

    private void SpawnObstacle() {
        Bounds obstacleBounds = new Bounds(player.position, Vector3.one * spreadRange);
        for (int i=0;i<noOfObstacles * spreadRange ;i++) {
            Vector3 spawnPosition = RandomPoints.RandomPointInBounds(obstacleBounds);

            if (Vector3.Distance(spawnPosition, player.position) > 35){
                Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], spawnPosition, Quaternion.identity);
            }
        }
    
    }

}
