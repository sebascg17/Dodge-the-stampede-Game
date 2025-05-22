using UnityEngine;

public class EnviarPerro : MonoBehaviour
{
    public GameObject perroPrefab;
    public GameObject player;
    public float cooldown = 1f; // Tiempo de espera entre cada invocación
    private float lastSpawnTime = -Mathf.Infinity; // Última vez que se invocó

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastSpawnTime + cooldown)
        {
            SpawnPerro();
            lastSpawnTime = Time.time; // Actualiza el tiempo del último spawn
        }
    }

    void SpawnPerro ()
    {
        Instantiate(perroPrefab, player.transform.position, perroPrefab.transform.rotation);
    }
}
