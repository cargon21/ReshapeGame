using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public GameObject LevelStartUI;
    bool StartLevel = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player" && !StartLevel)
        {
            LevelStartUI.SetActive(true);
            StartLevel = true;
            Invoke("DisableLevelStartUI", 2.0f);
        }
    }

    private void DisableLevelStartUI()
    {
        LevelStartUI.SetActive(false);
    }
}
