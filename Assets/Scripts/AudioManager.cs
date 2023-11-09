using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameOverSound;
    public AudioClip winSound;
    public AudioClip coinSound;

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOverSound);      
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void PlayCoin()
    {
        audioSource.PlayOneShot(coinSound);
    }
}
