using UnityEngine;

public class DestroyCollider : MonoBehaviour
{
        private void OnTriggerEnter ( Collider other )
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
            Destroy(gameObject); // destruye el animal al tocar al jugador
        }
        else if (other.CompareTag("Comida"))
        {
            GameManager.Instance.AddScore(10);
            Destroy(other.gameObject); // destruye la comida
            Destroy(gameObject); // destruye el animal
        }
    }

}
