using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnRangeZ = 10;
    private float spawnPosZ = 30;
    private float startDelay = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBallRoutine());
    }

    IEnumerator SpawnBallRoutine ()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            SpawnRandomAnimal();

            // Espera entre 2 a 5 segundos aleatorios
            float randomInterval = Random.Range(1f, 3f);
            yield return new WaitForSeconds(randomInterval);
        }
    }

    void SpawnRandomAnimal ()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject animal = animalPrefabs[animalIndex];

        // Decide desde qué lado aparecerá: 0 = arriba, 1 = izquierda, 2 = derecha
        int side = Random.Range(0, 3);

        Vector3 spawnPos = Vector3.zero;
        float x = Random.Range(-spawnRangeX, spawnRangeX);
        float z = Random.Range(-spawnRangeZ, spawnRangeZ);
        Quaternion rotation = Quaternion.identity;

        switch (side)
        {
            case 0: // Desde arriba
                spawnPos = new Vector3(x, 0, spawnPosZ);
                rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 1: // Desde la izquierda
                spawnPos = new Vector3(-spawnRangeX, 0, z);
                rotation = Quaternion.Euler(0, 90, 0);
                break;
            case 2: // Desde la derecha
                spawnPos = new Vector3(spawnRangeX, 0, z);
                rotation = Quaternion.Euler(0, -90, 0);
                break;
        }

        Instantiate(animal, spawnPos, rotation);
    }


}
