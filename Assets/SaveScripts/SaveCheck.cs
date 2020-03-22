using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveCheck : MonoBehaviour
{
    public UnityEvent OnLoadSucceded;
    public UnityEvent OnLoadFailed;

    // Start is called before the first frame update
    void Start()
    {
        if (SaveScript.LOAD())
        {
            OnLoadSucceded.Invoke();
        }
        else
        {
            OnLoadFailed.Invoke();
        }
        
    }
}
