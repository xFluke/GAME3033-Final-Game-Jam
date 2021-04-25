using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;
    bool isLeftSide = false;

    private void Start() {
        if (Random.value > 0.5) {
            spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z * -1);
            spawnPoint.rotation = Quaternion.Euler(0, -180, 0);
            isLeftSide = true;
        }

        StartCoroutine(SpawnVehicle());
    }

    IEnumerator SpawnVehicle() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            Debug.Log(spawnPoint.rotation.y);
            GameObject spawnedCar = Instantiate(car, spawnPoint.position, Quaternion.identity);

            if (isLeftSide) {
                spawnedCar.transform.rotation = Quaternion.AngleAxis(-180, Vector3.up);
            }
        }
    }
}
