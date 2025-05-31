using UnityEngine;
using UnityEngine.Audio;

public class ComidaRandom : MonoBehaviour
{
    public GameObject[] comidaPrefabs;
    public GameObject player;
    public AudioClip shotSound; // nuevo sonido
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
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
        Vector3 offset = new Vector3(0, 1, 0);

        if (shotSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shotSound);
        }

        Instantiate(comidaPrefabs[comidaIndex], player.transform.position + offset, comidaPrefabs[comidaIndex].transform.rotation);
    }
}
