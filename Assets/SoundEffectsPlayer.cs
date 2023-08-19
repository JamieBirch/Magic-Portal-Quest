using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    // public AudioClip ac1;

    public void playSound(AudioClip ac)
    {
        audioSource.clip = ac;
        audioSource.Play();
    }
}
