using UnityEngine;

public class GenerarPelota : MonoBehaviour
{
    public GameObject[] pelotaPrefabs;
    private float spawnRangeZ = 15;
    private float spawnPosY = 20;
    private float startDelay = 2;
    private float spawnInterval = Random.Range(3,5);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {
        InvokeRepeating("SpawnRamdomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update ()
    {

    }

    void SpawnRamdomAnimal ()
    {
        int pelotaIndex = Random.Range(0, pelotaPrefabs.Length);
        Vector3 spawnPos = new Vector3(0 , spawnPosY, Random.Range(-spawnRangeZ, spawnRangeZ));

        Instantiate(pelotaPrefabs[pelotaIndex], spawnPos, pelotaPrefabs[pelotaIndex].transform.rotation);
    }
}
