using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : GameBehaviour
{
    //Will Change Scene to the string passed in
    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
    //Reloads the current scene we are in
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    //Loads Title using string name
    public void ToTitleScene()
    {
        GameEvents.ReportGameStart();
        SceneManager.LoadScene("Title");
    }
    //Loads First GameLevel
    //Loads Title using string name
    public void StartingScene()
    {
        GameEvents.ReportGamePlaying();
        SceneManager.LoadScene("StarterForest");
    }

    //Gets Active Scene Name
    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //Quits our game
    public void QuitGame()
    {
        Application.Quit();
    }
}
