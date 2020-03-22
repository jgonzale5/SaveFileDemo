using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveScript.saveFile.lastScene = SceneManager.GetActiveScene().name;
        SaveScript.SAVE();
    }
}
