using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _audio; // sets the audio variable
    [SerializeField] Slider _volumeSlider; // the slider for the game object
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void VolumeSliderChanged()
    {
        _audio.volume = _volumeSlider.value;
    }
}
