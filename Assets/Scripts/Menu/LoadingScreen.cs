using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public string loadLevel;

    public GameObject loadingScreen;
    public Slider bar;

    public void Load ()
    {
        loadingScreen.SetActive(true);

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadLevel);

        asyncLoad.allowSceneActivation = false;

        while(!asyncLoad.isDone)
        {
            bar.value = asyncLoad.progress;
            if(asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                yield return new WaitForSeconds(0.5f);
                bar.value = 1f;
                yield return new WaitForSeconds(0.5f);
                asyncLoad.allowSceneActivation = true;
                
            }

            yield return null;
        }
    }
}
