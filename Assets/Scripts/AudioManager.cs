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

        // TODO: displaying a game over screen
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(winSound);

        // displaying a victory screen
    }

    public void PlayCoin()
    {
        audioSource.PlayOneShot(coinSound);
    }
}
