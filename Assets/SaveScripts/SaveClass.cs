using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveClass
{
    public string lastScene;

    private int score;

    public void ScoreIncrease()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }
}
