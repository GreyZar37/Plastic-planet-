using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffektsMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    public AudioClip[] sounds;
    public void clicked_()
    {
        audioSource.PlayOneShot(sounds[0]);
    }
    public void howered_()
    {
        audioSource.PlayOneShot(sounds[1]);

    }
    public void bookClosed_()
    {
        audioSource.PlayOneShot(sounds[2]);
    }
    public void typping_()
    {
        audioSource.PlayOneShot(sounds[3]);
    }
}
