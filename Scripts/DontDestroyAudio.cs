using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{

    static DontDestroyAudio instance = null;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void DestroyAudio()
    {
        Destroy(gameObject);
    }
    
}
