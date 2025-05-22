using UnityEngine;

public class ComidaRandom : MonoBehaviour
{
    public GameObject[] comidaPrefabs;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRamdomComida();
        }
    }

    void SpawnRamdomComida ()
    {
        int comidaIndex = Random.Range(0, comidaPrefabs.Length);

        Instantiate(comidaPrefabs[comidaIndex], player.transform.position, comidaPrefabs[comidaIndex].transform.rotation);
    }
}
