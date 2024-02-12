using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip backgroundMusic;
    AudioSource audioSource;
    static MusicManager instance;
    BoxCollider2D musicCollider;
    float musicVolume = 0.3f;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {   
        musicCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        PlayMusic();
    }

    void PlayMusic()
    {
        if (!audioSource.isPlaying && musicCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.volume = musicVolume;
            audioSource.Play();
        }
    }
}
