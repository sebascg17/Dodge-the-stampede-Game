using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Acceso global
    public GameObject gameOverPanel;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;

    private int score = 0; 

    public AudioClip hitSound; // nuevo sonido
    private AudioSource audioSource;

    private void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Awake ()
    {
        // Singleton para acceder fácilmente desde otros scripts
        if (Instance == null) Instance = this;
        UpdateScoreUI();
    }


    public void UpdateLivesUI ( int lives )
    {
        livesText.text = "Lives: " + lives;
    }

    public void AddScore ( int amount )
    {
        score += amount;
        UpdateScoreUI();
        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }

    public void UpdateScoreUI ()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            finalScoreText.text = scoreText.text;
        }
    }


    public void GameOver ()
    {
        // Ocultar los textos de vidas y score
        if (livesText != null)
            livesText.gameObject.SetActive(false);

        if (scoreText != null)
            scoreText.gameObject.SetActive(false);

        Debug.Log("Game Over!");
        StartCoroutine(PauseAfterShowPanel());
    }
    private IEnumerator PauseAfterShowPanel ()
    {
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Función para reiniciar la escena actual
    public void RestartGame ()
    {
        Time.timeScale = 1;
        // Mostrar los textos al reiniciar
        if (livesText != null)
            livesText.gameObject.SetActive(true);

        if (scoreText != null)
            scoreText.gameObject.SetActive(true);

        gameOverPanel.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Función para salir del juego
    public void QuitGame ()
    {
        Debug.Log("Quit Game");
        Application.Quit();

        // En el editor de Unity no se cierra la aplicación, por eso:
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
