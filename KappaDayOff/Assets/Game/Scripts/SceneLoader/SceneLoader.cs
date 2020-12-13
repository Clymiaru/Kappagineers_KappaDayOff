using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string     preloaderSceneName = "PreloaderScene";
    [SerializeField] private GameObject loadingScreen      = null;

    private static SceneLoader sharedInstance = null;
    public static SceneLoader Instance 
    {
        get => sharedInstance;
        private set => sharedInstance = value;
    }
    
    private string currentSceneName   = "PreloaderScene";
    
    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    private void Awake()
    {
        Instance = this;
    }
    
    // The game always has the preloader scene
    // The preloader scene contains global game objects that handle global data and functionality
    public void LoadScene(string sceneName)
    {
        // Load the loading screen scene with a UI overlay
        loadingScreen.gameObject.SetActive(true);
        
        Debug.Log("Scenes Active " + SceneManager.sceneCount.ToString());
        
        if (currentSceneName != preloaderSceneName && 
            SceneManager.sceneCount > 1)
        {
            scenesLoading.Add(SceneManager.UnloadSceneAsync(currentSceneName));
            Debug.Log("Current scene is not preloader " + currentSceneName);
        }
        
        currentSceneName = sceneName;

        // When the loading is complete, transition to the target scene
        scenesLoading.Add(SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }
    

    public IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }
        
        loadingScreen.gameObject.SetActive(false);
    }
    
    public static void LoadSceneDebug(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
