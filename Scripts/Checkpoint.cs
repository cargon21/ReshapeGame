using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointMaster cm;
    public GameObject checkpointUI;

    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointMaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            checkpointUI.SetActive(true);
            cm.lastCheckpointPos = transform.position;
            Invoke("DisableCheckpointUI", 2.0f);
        }
    }

    private void DisableCheckpointUI()
    {
        checkpointUI.SetActive(false);
    }
}  
