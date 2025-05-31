using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    private float speed = 25.0f;
    private float xRange = 20.0f;
    private float zRange = 10f;
    private int vidas = 3;

    private GameManager gameManager;
    public AudioClip hurtSound;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.UpdateLivesUI(vidas);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Limites();
        Move();
    }

    public void TakeDamage( int damage)
    {
        vidas -= damage;
        gameManager.UpdateLivesUI(vidas);

        if (hurtSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        if (vidas <= 0)
        {
            StartCoroutine(PauseAfterSound());
        }
    }
    private IEnumerator PauseAfterSound ()
    {
        yield return new WaitForSeconds(0.5f);
        gameManager.GameOver();
        gameObject.SetActive(false);
    }

    private void Move ()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, forwardInput);
        transform.Translate(movement * speed * Time.deltaTime);

    }

    private void Limites ()
    {

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        else if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }
}
