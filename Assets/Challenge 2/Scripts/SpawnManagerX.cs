using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitMinX = 5;
    private float spawnLimitMaxX = 30;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4;

    // Start is called before the first frame update
    void Start()
    {
        startDelay = Random.Range(3, 5);
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(0, spawnPosY, Random.Range(spawnLimitMinX, spawnLimitMaxX));

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

}
