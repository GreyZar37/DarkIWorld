using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Slider SfxSlider, musicSlider;
    public AudioSource sfxSource, musicSource;
    

    public static float sfxVolume, musicVolume;


    
    // Start is called before the first frame update
    void Start()
    {
        getVolume();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void getVolume(){
        sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);

        sfxSource.volume = sfxVolume;
        musicSource.volume = musicVolume;

        SfxSlider.value = sfxVolume;
        musicSlider.value = musicVolume;


    }
    
    public void setVolume()
    {
        sfxVolume = sfxSource.volume;
        musicVolume = musicSource.volume;

        PlayerPrefs.SetFloat("SfxVolume", sfxVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        sfxSource.volume = SfxSlider.value;
        musicSource.volume = musicSlider.value;
        

    }
}
