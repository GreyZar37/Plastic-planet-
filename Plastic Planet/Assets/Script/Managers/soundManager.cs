using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{

    public AudioSource[] audioSourcesSFX;
    public AudioSource[] audioSourcesMusic;

    public float audioVolumeSFX = 1;
    public float audioVolumeMusic = 0.5f;

    public Slider sfxSlider;
    public Slider musicSlider;



    // Start is called before the first frame update
    void Start()
    {
        audioVolumeSFX = PlayerPrefs.GetFloat("audioVolumeSFX", audioVolumeSFX);
        audioVolumeMusic = PlayerPrefs.GetFloat("audioVolumeMusic", audioVolumeMusic);

        sfxSlider.value = audioVolumeSFX;
        musicSlider.value = audioVolumeMusic;

    }

    // Update is called once per frame
    void Update()
    {
        audioVolumeSFX = sfxSlider.value;
        audioVolumeMusic = musicSlider.value;

        for (int i = 0; i < audioSourcesSFX.Length; i++)
        {
            audioSourcesSFX[i].volume = audioVolumeSFX;
        }

        for (int i = 0; i < audioSourcesMusic.Length; i++)
        {
            audioSourcesMusic[i].volume = audioVolumeMusic;
        }
        PlayerPrefs.SetFloat("audioVolumeSFX", audioVolumeSFX);
        PlayerPrefs.SetFloat("audioVolumeMusic", audioVolumeMusic);
    }
}
