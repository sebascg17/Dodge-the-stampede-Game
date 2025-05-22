using UnityEngine;

public class EnviarPerro : MonoBehaviour
{
    public GameObject perroPrefab;
    public GameObject player;
    public float cooldown = 1f; // Tiempo de espera entre cada invocaci�n
    private float lastSpawnTime = -Mathf.Infinity; // �ltima vez que se invoc�

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastSpawnTime + cooldown)
        {
            SpawnPerro();
            lastSpawnTime = Time.time; // Actualiza el tiempo del �ltimo spawn
        }
    }

    void SpawnPerro ()
    {
        Instantiate(perroPrefab, player.transform.position, perroPrefab.transform.rotation);
    }
}
