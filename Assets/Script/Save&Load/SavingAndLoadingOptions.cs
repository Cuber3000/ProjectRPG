using UnityEngine;
using System.IO;

public class SavingAndLoadingOptions : MonoBehaviour
{
    string _filePath = $"{Application.dataPath}/Save/SavedMenuData.Json"; // This will be the path that the JSON will save to, and using {Application.dataPath} will make sure it's saved in the asset folder.


    public MenuToSave menuData = new MenuToSave();

    [Header("Options Data")] // Groups everything together in the inspector to make things easier.

    [SerializeField] Audio _audioLevel; // this will save the volume level from the slider
    [SerializeField] Quality _quality; // this will save the selected quality level from the dropdown
    [SerializeField] KeyBinds _keyBinds;//  this will save the selected keybinds.

    void StuffToSave() // the data that needs to be saved.
    {
        menuData.volumeLevel = _audioLevel._volumeSlider.value; // This will save the current value that the volume slider is at.
        menuData.keyBindNames = _keyBinds.SendKey(); // this will save the names of the keybinds, such as "Left"
        menuData.keyBindValues = _keyBinds.SendValue(); // this will save the values of the keybinds, such as "A"
        menuData.quality = _quality.CurrentQualityIndex; // grabs the current index that had been selected.
    }

    void SaveToJSON(MenuToSave data, string path)
    {
        string dataToSave = JsonUtility.ToJson(data); // converts data to JSON string
        File.WriteAllText(path, dataToSave); // write string to the file
    }

    public void SaveMenu() // Will put this onto a button to save.
    {
        StuffToSave();  // Fathers current settings
        SaveToJSON(menuData, _filePath); // Saves those to the file.
    }

    MenuToSave LoadData()
    {
        string loadData  = File.ReadAllText(_filePath); // reads the JSON string
        return JsonUtility.FromJson<MenuToSave>(loadData); // converts teh json string into data again.
    }

    void DataFromLoad()
    {
        _audioLevel._volumeSlider.value = menuData.volumeLevel; // Will move the slider value to where it should visibly be.
        _audioLevel._audio.volume = menuData.volumeLevel; // Will make sure that the audio is not audibly different to the slider.
        _keyBinds.SetUpLoadedKeys(menuData.keyBindNames, menuData.keyBindValues); // will update the keys accordingly.
        _quality.CurrentQualityIndex = menuData.quality; // will make sure that the previously selected index is selected now.

    }
    public void LoadMenu() // puts the two above functions together essentially. Can be applied to a button to force a load
    {
        menuData = LoadData();
        DataFromLoad();
    }
    
    private void Awake() // this will before even Start(), just checking to make sure that there is a file there already.
    {
        if (File.Exists(_filePath))
        {
            LoadMenu();
        }
    }

}
