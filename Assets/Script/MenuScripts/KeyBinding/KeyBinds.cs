using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class KeyBinds : MonoBehaviour
{
    [Serializable]
    public struct ActionMapData // Holds the information of each of the action's keybinding
    {
        public string actionName; // the name of the action, such as Jump
        public Text keyDisplay; // the UI that displays the assigned key.
        public string defaultKey; // the key as a string, such as space
    }

    // Variables for the binding of keys
    [Header("Action Mapping")]
    [SerializeField] ActionMapData[] _actionMapData; // Makes an viewable array in the inspector showing the actions and their bindings.
    [Header("UI Feedback")]
    [SerializeField] GameObject _currentSelectedKey; // The button that the player is currently modifying
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>(); // maps action name to keycodes

    // Colours for visual feedback.
    [SerializeField] private Color32 _selectedKey = new Color32(113, 116, 113, 130); // Colour when selecting a new key.
    [SerializeField] private Color32 _changedKey = new Color32(222, 222, 222, 130);

    // Sets up the keys from a loaded configuration.
    public void SetUpLoadedKeys(string[] key, string[] value)
    {
        // Reset the current Key Mappings
        keys.Clear(); // clearing the array
        for (int i = 0; i < key.Length; i++) // Goes through each element of the key array and adds elements from the KeyCode dictionary.
        {
            keys.Add(key[i], (KeyCode)Enum.Parse(typeof(KeyCode), value[i])); // Pairs the dictionary to the element.
        }       
    }
    // Turns the array into a JSON utility due to json not handli
    public string[] SendKey()
    {
        string[] tempKey = new string[keys.Count]; // Create an array to hold the key names
        int i = 0; // Create an int to hold the current array element
        foreach (KeyValuePair<string, KeyCode> key in keys) // loop through the dictionary to extract key names.
        {
            // stores the key name in the array.
            tempKey[i] = key.Key;
            i++; //move to next index
        }
        return tempKey;
    }
    // Returns the key values as an array
    public string[] SendValue()
    {
        //create an array to hold the key values
        string[] tempValue = new string[keys.Count];
        int i = 0; //create an int to hold the current array element

        // loop throught the dictionary to grab key values
        foreach (KeyValuePair<string, KeyCode> key in keys)
        {
            tempValue[i] = keys.Values.ToString(); // Store the value from KeyCode as a string in the array.
            i++; //Head to the enext index
        }
        // Return key values
        return tempValue;
    }


    // Starts the keybindings, binding of the keys pretty much
    // and updates the UI elements
    private void Start()
    {
        for (int i = 0; i < _actionMapData.Length; i++) // loops through each action in the keybinding array
        {
            
            if (!keys.ContainsKey(_actionMapData[i].actionName)) // Checks if the action is in the dictionary
            {
                // adds defauilt key if not in the dictionary.
                keys.Add(_actionMapData[i].actionName, (KeyCode)Enum.Parse(typeof(KeyCode), _actionMapData[i].defaultKey));
            }
            // Updates UI and shows assigned key in the text
            _actionMapData[i].keyDisplay.text = keys[_actionMapData[i].actionName].ToString();
        }
    }

    // Is used then the user clicks a UI button to change a keybinding, the button's name has to match the action name in the dictionary
    public void ChangeKey(GameObject selectedKey)
    {
        // Store clicked button as the one being edited
        _currentSelectedKey = selectedKey;
        
        // visually indicates it's ready for key input
        if (_currentSelectedKey != null)
        {
            _currentSelectedKey.GetComponent<Image>().color = _selectedKey;
        }
    }

    // OnGUI detects key presses per frame, it only runs when a keybinding change is in progress and uses the unity Event System
    private void OnGUI()
    {
        Event changeKeyEvent = Event.current; // Get's the current UI/Input event.

        if (_currentSelectedKey != null && changeKeyEvent.isKey) // check if there's a selected button and the event is a key being pressed.
        {
            if (!keys.ContainsValue(changeKeyEvent.keyCode)) // only continues if the key isn't already being assigned.
            {
                keys[_currentSelectedKey.name] = changeKeyEvent.keyCode; // updates the dictionary with the new key.

                _currentSelectedKey.GetComponentInChildren<Text>().text = changeKeyEvent.keyCode.ToString(); // Update the button to reflect the new key

                _currentSelectedKey.GetComponent<Image>().color = _changedKey; // Change colour to indicate success.

                _currentSelectedKey = null; // Resets selection to be able to select the next one.
            }
        }
    }
}
