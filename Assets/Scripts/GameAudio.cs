using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip collisionSound;
    public AudioClip passSound;

    public void PlayCollision()
    {
        audioSource.PlayOneShot(collisionSound);
    }

    public void PlayPass()
    {
        audioSource.PlayOneShot(passSound);
    }

    public void StopFlyingSound()
    {
        audioSource.Stop();
    }
}