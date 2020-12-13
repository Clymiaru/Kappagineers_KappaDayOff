using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveHandler
{
    private const string DefaultPathDestination = "SaveData";
    
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

    private string saveFileDirectory = Path.Combine(Application.persistentDataPath, DefaultPathDestination);
    public string SaveFileDirectory
    {
        get => saveFileDirectory;
        set
        {
            string path = value;
            path = Path.Combine(Application.persistentDataPath, path);
            
            saveFileDirectory = path;
        }
    }

    public void Save(SaveData data, string saveName)
    {
        string path = Path.Combine(SaveFileDirectory, saveName);

        if (!Directory.Exists(SaveFileDirectory))
        {
            Directory.CreateDirectory(SaveFileDirectory);
        }
        
        var formatter = new BinaryFormatter();
        
        using (var stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
        
        Debug.Log($"Save successful!! {path}");
    }

    public SaveData Load(string saveName)
    {
        SaveData data = null;
        string   path = Path.Combine(SaveFileDirectory, saveName);
        
        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
                
            using (var stream = new FileStream(path, FileMode.Open))
            {
                data = formatter.Deserialize(stream) as SaveData;
            }
        }
        else
        {
            Debug.LogError($"Save data not found!! ({path})");
        }
        
        return data;
    }
}
