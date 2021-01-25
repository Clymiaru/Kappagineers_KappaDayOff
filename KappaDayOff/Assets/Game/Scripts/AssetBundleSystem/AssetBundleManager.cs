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

    private AssetBundleManager()
    {
    }



}
