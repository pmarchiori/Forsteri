using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public void ChooseScene(string lvlName)
    {
        StartCoroutine(DelaySceneLoad(lvlName));
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame(string levelSelectionScene)
    {
        SceneManager.LoadScene(levelSelectionScene);
    }

    IEnumerator DelaySceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(.12f);
        SceneManager.LoadScene(sceneName);
    }
}
