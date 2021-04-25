using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclePrefabs;
    [SerializeField] int minNumberOfObstaclesToSpawn;
    [SerializeField] int maxNumberOfObstaclesToSpawn;

    [SerializeField] int maximumZValue;

    float zPositionOffset = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        int numberOfObstaclesToSpawn = Random.Range(minNumberOfObstaclesToSpawn, maxNumberOfObstaclesToSpawn + 1);
        int randomStartingZValue = Random.Range(4, maximumZValue + 1) * -1;
        int maxObstacleSlots = maximumZValue * 2 + 1;

        float currentZPosition = randomStartingZValue * zPositionOffset;




        for (int i = 0; i < numberOfObstaclesToSpawn; i++) {
            GameObject randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

            GameObject spawnedObstacle = Instantiate(randomObstacle);
            spawnedObstacle.transform.SetParent(transform);
            spawnedObstacle.transform.localPosition = new Vector3(0, spawnedObstacle.transform.position.y, currentZPosition);

            currentZPosition += Random.Range(4, 9) * 0.05f;
        }
    }
}
