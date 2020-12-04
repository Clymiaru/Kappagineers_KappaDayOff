using System.Collections;
using UnityEngine;

using Text = TMPro.TMP_Text;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Text promptText = null;

    private bool isLoadingFinished = false;
    
    private void Start()
    {
        isLoadingFinished = false;
        StartCoroutine(Timer(2.0f,
                             () =>
                             {
                                 // Send event to loading successful
                                 isLoadingFinished = true;
                                 promptText.text   = "Tap anywhere to start";
                             }));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isLoadingFinished)
        {
            OnTap();
        }
    }
    private IEnumerator Timer(float seconds, System.Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();
    }

    public void OnTap()
    {
        SceneLoader.LoadScene(SceneNames.MainMenu);
    }
}
