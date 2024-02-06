using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 1;

    bool isCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isCollected)
        {
            isCollected = true;

            GameObject audioSourceObject = new GameObject("AudioSource");
            AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(coinPickupSFX);
            Destroy(audioSourceObject, coinPickupSFX.length);

            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
