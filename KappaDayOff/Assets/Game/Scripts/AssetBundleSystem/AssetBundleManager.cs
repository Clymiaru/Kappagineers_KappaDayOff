using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetBundleManager
{
	public static AssetBundleManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new AssetBundleManager();
			}
			return instance;
		}
	}
	private static AssetBundleManager instance;

	private string BundlesRootPath
	{
		get
		{
#if UNITY_EDITOR
			return Application.streamingAssetsPath;
#elif UNITY_ANDROID
                return Application.persistentDataPath;
#else
                return null;
#endif
		}
	}

    private Dictionary<string, AssetBundle> loadedBundles = new Dictionary<string, AssetBundle>();

    private AssetBundleManager()
    {
    }

    public AssetBundle LoadBundle(string bundleName)
    {
	    if (loadedBundles.ContainsKey(bundleName))
	    {
		    return loadedBundles[bundleName];
	    }

	    AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine(BundlesRootPath, bundleName));

	    if (bundle == null)
	    {
		    Debug.LogError($"{bundleName} does not exist!");
	    }
	    else
	    {
		    loadedBundles.Add(bundleName, bundle);
	    }

	    return bundle;
    }

    public T GetAsset<T>(string bundleName, string assetName) where T : Object
    {
	    T retrievedAsset = null;

	    AssetBundle bundle = LoadBundle(bundleName);

	    if (bundle != null)
	    {
		    retrievedAsset = bundle.LoadAsset<T>(assetName);
	    }

	    return retrievedAsset;
    }
}
