using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class KeyBinds : MonoBehaviour
{
    [Serializable]
    public struct ActionMapData // Holds the information of each of the action's keybinding
    {
        public string actionName; // Name assigned to action. E.g: Jump, Crouch, Sprint, etc.
        public Text keyDisplay; // Text so the UI can display the keys assigned.
        public string defaultKey; // Displays the name of the button assigned to the action. Eg: Press "Space" to Jump, Hold "CTRL" to Crouch, etc.
    }

    // Keybinding Variables
    [Header("Action Mapping")]
    [SerializeField] ActionMapData[] _actionMapData; // Creates a viewable array in the inspector to show the actions and the keybinds associated.
    [Header("UI Feedback")]
    [SerializeField] GameObject _currentSelectedKey; // Displays the button the player is currently editing.
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>(); // Maps pathways for action name to keycodes.

    // Colours for player's visual feedback.
    [SerializeField] private Color32 _selectedKey = new Color32(113, 116, 113, 130); // Colour when players is selecting a new key.
    [SerializeField] private Color32 _changedKey = new Color32(222, 222, 222, 130);

    // Loads in and sets up the keys from a loaded configuration.
    public void SetUpLoadedKeys(string[] key, string[] value)
    {
        // Reset the current Key Mappings.
        keys.Clear(); // This clears the array.
        for (int i = 0; i < key.Length; i++) // Goes through each element of the key array and adds elements from the KeyCode dictionary.
        {
            keys.Add(key[i], (KeyCode)Enum.Parse(typeof(KeyCode), value[i])); // Pairs the dictionary to the element.
        }       
    }
    // Transforms the array into a JSON utility.
    public string[] SendKey()
    {
        string[] tempKey = new string[keys.Count]; // Creates an array to hold the names of the key names.
        int i = 0; // Create an int to hold the current array element.
        foreach (KeyValuePair<string, KeyCode> key in keys) // Loops through the dictionary to extract key names.
        {
            // Stores the key name in the array.
            tempKey[i] = key.Key;
            i++; // Moves to the next index.
        }
        return tempKey;
    }
    // Returns the key values back as an array.
    public string[] SendValue()
    {
        // Creates an array to hold the key values.
        string[] tempValue = new string[keys.Count];
        int i = 0; //create an int to hold the current array element

        // Loops through the dictionary to grab key values.
        foreach (KeyValuePair<string, KeyCode> key in keys)
        {

            tempValue[i] = key.Value.ToString(); // Store the value from KeyCode as a string in the array.
            i++; //Head to the enext index

        }
        // Return key values
        return tempValue;
    }


    // Starts the keybindings.
    // Updates the UI elements.
    private void Start()
    {
        for (int i = 0; i < _actionMapData.Length; i++) // Loops through each action in the keybinding array.
        {
            
            if (!keys.ContainsKey(_actionMapData[i].actionName)) // Checks if the action is in the dictionary.
            {
                // Adds default key if action is not in the dictionary.
                keys.Add(_actionMapData[i].actionName, (KeyCode)Enum.Parse(typeof(KeyCode), _actionMapData[i].defaultKey));
            }
            // Updates UI and shows assigned key in text.
            _actionMapData[i].keyDisplay.text = keys[_actionMapData[i].actionName].ToString();
        }
    }

    // When the player clicks a UI button to change a keybind, this will check that the button's name matches the action name in the dictionary.
    public void ChangeKey(GameObject selectedKey)
    {
        // Stores information of the selected button being edited. 
        _currentSelectedKey = selectedKey;
        
        // Visually indicates it's ready for the new key input.
        if (_currentSelectedKey != null)
        {
            _currentSelectedKey.GetComponent<Image>().color = _selectedKey;
        }
    }

    // OnGUI detects key presses per frame, it only runs when a keybinding change is in progress and uses the unity Event System.
    private void OnGUI()
    {
        Event changeKeyEvent = Event.current; // Obtains the current UI/Input event.

        if (_currentSelectedKey != null && changeKeyEvent.isKey) // Checks if there is a selected button and that the event is a key being pressed.
        {
            if (!keys.ContainsValue(changeKeyEvent.keyCode)) // Only continues if the key isn't already being assigned.
            {
                keys[_currentSelectedKey.name] = changeKeyEvent.keyCode; // Updates the dictionary with the new key.

                _currentSelectedKey.GetComponentInChildren<Text>().text = changeKeyEvent.keyCode.ToString(); // Updates the button to reflect the new key.

                _currentSelectedKey.GetComponent<Image>().color = _changedKey; // Changes the colour to indicate successfull change.

                _currentSelectedKey = null; // Resets selection to allow a new key to be selected.
            }
        }
    }
}
