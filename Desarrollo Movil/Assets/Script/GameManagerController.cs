using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagerController : MonoBehaviour
{
    [Header("Load Scene Variables")]

    public Button btnLoadScene;
    public string sceneToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        btnLoadScene.onClick.AddListener(() => LoadScene());
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ActivateLoadingCanvas()
    {
        StartCoroutine(LoadLevelWithRealProgress());
    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        AsyncOperation operationSync = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!operationSync.isDone)
        {
            yield return null;
        }
    }

    public void ChangeMusicState()
    {
        MusicManagerController.musicManagerController.ChangeMusicState();
    }
}
