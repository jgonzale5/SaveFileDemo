using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    public UnityEvent OnWin;
    public UnityEvent OnLose;
    public static ManagerScript Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        OnWin.Invoke();
        SaveScript.saveFile.ScoreIncrease();
    }

    public void Lose()
    {
        OnLose.Invoke();
    }

    public void LoadSaveFile()
    {
        bool loadSuccess = SaveScript.LOAD();

        if (loadSuccess)
            SceneManager.LoadScene(SaveScript.saveFile.lastScene);
    }

    public void LoadScene(string withName)
    {
        SceneManager.LoadScene(withName);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
