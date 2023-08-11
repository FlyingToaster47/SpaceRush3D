using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] collectiblePrefabs;
    [SerializeField] private Transform player;
    [Range(1, 6)]
    [SerializeField] private int noOfCollectibles = 4;
    [SerializeField] private int spreadRange = 500;


    private void Start() {
        GenerateSpawnPositions();
    }


    private void GenerateSpawnPositions() {
        Bounds collectibleBounds = new Bounds(player.position, Vector3.one * spreadRange);
        for (int i=0;i<noOfCollectibles * spreadRange;i++) {
            Vector3 spawnPosition = RandomPoints.RandomPointInBounds(collectibleBounds);
            Instantiate(collectiblePrefabs[Random.Range(0, collectiblePrefabs.Length)], spawnPosition, Quaternion.identity);
        }
    }


}
