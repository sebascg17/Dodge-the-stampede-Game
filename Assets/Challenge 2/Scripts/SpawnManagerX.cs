using System.Collections;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitMinX = 5;
    private float spawnLimitMaxX = 30;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;

    void Start ()
    {
        StartCoroutine(SpawnBallRoutine());
    }

    IEnumerator SpawnBallRoutine ()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            SpawnRandomBall();

            // Espera entre 2 a 5 segundos aleatorios
            float randomInterval = Random.Range(1f, 4f);
            yield return new WaitForSeconds(randomInterval);
        }
    }

    void SpawnRandomBall ()
    {
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        Vector3 spawnPos = new Vector3(0, spawnPosY, Random.Range(spawnLimitMinX, spawnLimitMaxX));

        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
}
