using System.IO;
using System.Xml;
using UnityEngine;

public class StatSaveAndLoad : MonoBehaviour
{
    string _filePath = $"{Application.dataPath}/Save/SavedStatData.Json";// This will be the path that the JSON will save to, and using {Application.dataPath} will make sure it's saved in the asset folder.

    public StatToSave statData = new StatToSave();

    // [Header("Stats Data")] // Groups it all together in the inspector to make it easier to view.

    // [SerializeField] StatsAndLeveling _stat; // this will call up the variables from the script.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void StuffToSave()
    { // commented out due to no available stats
        
        /*statData.name = _stat.name;
         *statData.health = _stat.health.value;
         *statData.stamina = _stat.stamina.value;
         *statData.level = _stat.level;
         *statData.experience = _stat.experience.value;
         *statData.stats = _stat.List<Stat>;
         */
    }

    // Update is called once per frame
    void SaveToJson(StatToSave data, string path)
    {
        string thingsToSave = JsonUtility.ToJson(data); // turns the data into a JSON string
        File.WriteAllText(path, thingsToSave); // write the string to the file.
    }

    public void SaveStat() // Save Stat Button
    {
        StuffToSave(); // Grabs current settings
        SaveToJson(statData, _filePath); // Throws settings into file.
    }

    StatToSave LoadData()
    {
        string loadData = File.ReadAllText(_filePath); // Reads the JSON
        return JsonUtility.FromJson<StatToSave>(loadData); // Turns JSON into data.
    }

    void DataFromLoad() // Puts data into play.
    { // No stat script to use as base

        /* _stat.name = statData.name
         * _stat.health.value = statData.health
         * _stat.stamina.value = statData.stamina
         * _stat.level = statData.level
         * _stat.experience.value = statData.experience
         * _stat.List<Stat> = statData.Stat          
         */
    }
    public void LoadStat() // Load Button
    {
        statData = LoadData();
        DataFromLoad();
    }

    private void Awake() // Makes sure that there is a file.
    {
        if (File.Exists(_filePath))
        {
            LoadData();
        }
    }
}
