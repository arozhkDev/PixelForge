using UnityEngine;

public class HeartPickup : MonoBehaviour
{

    [SerializeField] AudioClip heartPickupSFX;
    [SerializeField] int healthForPickup = 1;

    bool isCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isCollected)
        {
            isCollected = true;

            GameObject audioSourceObject = new GameObject("AudioSource");
            AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
            audioSource.volume = 0.6f;
            audioSource.PlayOneShot(heartPickupSFX);
            Destroy(audioSourceObject, heartPickupSFX.length);

            FindObjectOfType<GameSession>().Heal(healthForPickup);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
