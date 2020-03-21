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
    }

    public void Lose()
    {
        OnLose.Invoke();
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
