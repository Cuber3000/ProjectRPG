using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Audio : MonoBehaviour
{
    [SerializeField] public AudioSource _audio; // sets the audio variable
    [SerializeField] public Slider _volumeSlider; // the slider for the game object
    public float volumeLevel;
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
