using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveDataManager
{
	private const string PathDestination   = "SaveData";
	private const string SaveFileExtension = "dat";
	private const string SaveName          = "playerSave";

	public SaveData PlayerSaveData { get; private set; }

	private static SaveDataManager instance;
	public static SaveDataManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new SaveDataManager();
			}

			return instance;
		}
	}

	private static string RootPath
	{
		get
		{
			#if UNITY_EDITOR
			return Application.persistentDataPath;
			#elif UNITY_ANDROID
			return "";
			#endif
		}
	}


	public void Save()
	{
		if (PlayerSaveData == null)
		{
			PlayerSaveData = new SaveData();
			return;
		}

		string directoryPath = Path.Combine(RootPath, PathDestination);
		string path          = Path.Combine(directoryPath, $"{SaveName}.{SaveFileExtension}");

		if (!Directory.Exists(directoryPath))
		{
			Directory.CreateDirectory(directoryPath);
		}

		var formatter = new BinaryFormatter();

		using (var stream = new FileStream(path, FileMode.Create))
		{
			formatter.Serialize(stream, PlayerSaveData);
		}

		Debug.Log($"Save successful!! {path}");
	}

	public void Load()
	{
		string directoryPath = Path.Combine(RootPath, PathDestination);
		string path          = Path.Combine(directoryPath, $"{SaveName}.{SaveFileExtension}");

		if (File.Exists(path))
		{
			var formatter = new BinaryFormatter();

			using (var stream = new FileStream(path, FileMode.Open))
			{
				PlayerSaveData = formatter.Deserialize(stream) as SaveData;
			}
		}
		else
		{
			Save();
		}
	}
}
