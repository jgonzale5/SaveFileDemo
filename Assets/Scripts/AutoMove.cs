using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public Transform[] nodes;
    private int currentInd = 0;
    public bool paused = false;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused && currentInd < nodes.Length)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                nodes[currentInd].position,
                Time.deltaTime * speed);

            if (this.transform.position == nodes[currentInd].position)
            {
                currentInd++;
            }
        }
    }
}
