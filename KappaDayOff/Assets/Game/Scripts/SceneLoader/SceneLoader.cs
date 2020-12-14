using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader sharedInstance = null;
    public static SceneLoader Instance 
    {
        get => sharedInstance;
        private set => sharedInstance = value;
    }
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
