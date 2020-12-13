using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveHandler
{
    // [Tooltip("Path to the save file after reaching the Game's Directory")]
    private string saveFileDirectory = "SaveData";
    
    // [Tooltip("File name of the save data including the type")]
    private string saveDataName = "TestData.test";
    
    private static SaveHandler sharedInstance = null;
    public static SaveHandler Instance 
    {
        get 
        {
            if (sharedInstance == null) 
            {
                sharedInstance = new SaveHandler();
            }

            return sharedInstance;
        }
    }

    public string SaveDataDirectory
    {
        get
        {
            string path = Application.persistentDataPath;
            path = Path.Combine(path, saveFileDirectory);
            path = Path.Combine(saveDataName);
            return path;
        }
    }

    public void Save(SaveData data)
    {
        var formatter = new BinaryFormatter();
        
        using (var stream = new FileStream(SaveDataDirectory, FileMode.Create))
        {
            formatter.Serialize(stream, data);
            stream.Close();
        }
        
        Debug.Log(SaveDataDirectory);
    }

    public SaveData Load()
    {
        SaveData data = null;
        
        if (File.Exists(SaveDataDirectory))
        {
            var formatter = new BinaryFormatter();
                
            using (var stream = new FileStream(SaveDataDirectory, FileMode.Open))
            {
                data = formatter.Deserialize(stream) as SaveData;
                stream.Close();
            }
        }
        else
        {
            Debug.LogError($"Save data not found!! ({SaveDataDirectory})");
        }
        
        return data;
    }
}
