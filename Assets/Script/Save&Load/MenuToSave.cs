using UnityEngine;
using System;

// Serialized in order to save the quality, audio and keybinds settings.
[Serializable]
public class MenuToSave
{
    [Header("Audio")]
    public float volumeLevel; // float due to slider being between 0 and 1

    [Header("Quality")]
    public int quality; // 0 is low, 1 is medium, 3 is high. And these match the Uniti Quality setting.

    [Header("KeyBinds")]
    public string[] keyBindNames; // the name of the key, such as "Backward"

    public string[] keyBindValues; // the value assigned to the key, such as "S" for "Backward"
}
