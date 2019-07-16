using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeChange : MonoBehaviour
{
    [SerializeField] AudioSource[] MusicAudioSrcs = null;
    [SerializeField] Slider slider = null;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
        UpdateVolume();
    }

    public void SetVolume(float vol)
    {
        PlayerPrefs.SetFloat("MusicVolume", vol);
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        for (int i = 0; i < MusicAudioSrcs.Length; i++)
        {
            MusicAudioSrcs[i].volume = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
        }
    }
}
