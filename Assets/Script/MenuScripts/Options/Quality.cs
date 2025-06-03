using UnityEngine;
using UnityEngine.UI;

public class Quality : MonoBehaviour
{
    [SerializeField] Dropdown _qualityDropdown; // refers to the UI dropdown component that let's the player change the quality settings.
    int _currentQualityIndex = 0; // Variable that tracks the current quality level index.


    public int CurrentQualityIndex // Gets or Sets the index of the current quality level, this unit represents the settings defined in Edit > Project Settings > Quality.
    {
        set { _currentQualityIndex = value; }
        get {  return _currentQualityIndex; }
    }

    // Changes the game quality based on the index, predefined by the Unity Editor (Edit > Project Settings > Quality.), 0 is the lowest quality with higher numbers being better quality.
    public void ChangeQuality(int qualityIndex)
    {
        CurrentQualityIndex = qualityIndex; // Update the current quality index with the new value selected by the player.

        QualitySettings.SetQualityLevel(CurrentQualityIndex); // Sets the quality in the game to match what the index is set to, and uses the inbuilt Unity Quality Settings to do so.
    }

    private void Start()
    {
        _qualityDropdown.value = CurrentQualityIndex; // Updates the dropdown element to show the current quality of the game
        QualitySettings.SetQualityLevel(_currentQualityIndex);  // Match the quality level
    }
}
