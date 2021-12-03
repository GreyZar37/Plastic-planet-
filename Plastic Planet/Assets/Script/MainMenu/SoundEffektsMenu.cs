using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffektsMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    public AudioClip clicked;
    public AudioClip howered;

    public AudioClip bookClosed;


    public void clicked_()
    {
        audioSource.PlayOneShot(clicked);
    }
    public void howered_()
    {
        audioSource.PlayOneShot(howered);

    }
    public void bookClosed_()
    {
        audioSource.PlayOneShot(bookClosed);
    }
}
