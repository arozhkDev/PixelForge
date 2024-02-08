using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    Player player;
    [SerializeField] AudioClip backgroundMusic;
    AudioSource audioSource;

    void Awake()
    {
        player = FindObjectsOfType<Player>()[0];
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = $"{score}$";
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            RestartLevel();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = $"{score}$";
    }

    public void Heal(int pointsToAdd)
    {
        playerLives += pointsToAdd;
        livesText.text = playerLives.ToString();
    }

    void RestartLevel()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void PlayBackgroundMusic()
    {
        GameObject audioSourceObject = new GameObject("AudioSource");
        audioSource = audioSourceObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
