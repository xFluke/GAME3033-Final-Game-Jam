using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    Vector3 currentPosition;

    [SerializeField] int maxTerrainCount;

    [SerializeField] Terrain[] terrainObjects;
    List<GameObject> spawnedTerrains;

    [SerializeField] Transform terrainParentObject;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = new Vector3(0, 0, 0);
        spawnedTerrains = new List<GameObject>();

        for (int i = 0; i < maxTerrainCount; i++) {
            SpawnStartingTerrain();
        }
        maxTerrainCount = spawnedTerrains.Count;
    }

    void SpawnStartingTerrain() {
        Terrain randomTerrain = terrainObjects[Random.Range(0, terrainObjects.Length)];

        int numOfTerrainToSpawnInSuccession = Random.Range(1, randomTerrain.maxNumInSuccession);
        for (int i = 0; i < numOfTerrainToSpawnInSuccession; i++) {
            GameObject spawnedTerrain = Instantiate(randomTerrain.terrainPrefab, currentPosition, Quaternion.identity, terrainParentObject);
            spawnedTerrains.Add(spawnedTerrain);
            currentPosition.x++;
        }
    }

    void SpawnTerrain() {
        Terrain randomTerrain = terrainObjects[Random.Range(0, terrainObjects.Length)];

        int numOfTerrainToSpawnInSuccession = Random.Range(1, randomTerrain.maxNumInSuccession);
        for (int i = 0; i < numOfTerrainToSpawnInSuccession; i++) {
            GameObject spawnedTerrain = Instantiate(randomTerrain.terrainPrefab, currentPosition, Quaternion.identity, terrainParentObject);
            spawnedTerrains.Add(spawnedTerrain);
            if (spawnedTerrains.Count > maxTerrainCount) {
                Destroy(spawnedTerrains[0]);
                spawnedTerrains.RemoveAt(0);
            }
            currentPosition.x++;
        }
       
    }
}
