using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip ac1;

    public void playSound()
    {
        audioSource.clip = ac1;
        audioSource.Play();
    }
}
