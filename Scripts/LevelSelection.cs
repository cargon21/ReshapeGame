using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 3);
        for(int i = 0; i < lvlButtons.Length; i++)
        {
            if(i + 3 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }
    /*
    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
    */
}
