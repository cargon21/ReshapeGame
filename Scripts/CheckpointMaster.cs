using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMaster : MonoBehaviour
{
    private static CheckpointMaster instance;
    public Vector3 lastCheckpointPos = new Vector3(0, 2, 0);

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
