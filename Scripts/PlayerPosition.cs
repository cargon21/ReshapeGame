using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public static bool spawn = false;
    private CheckpointMaster cm;

    void Start()
    {
        if (spawn == true)
        {
            cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointMaster>();
            transform.position = cm.lastCheckpointPos;
        }
        
        else
        {
            spawn = true;
        }
        
    }
}
