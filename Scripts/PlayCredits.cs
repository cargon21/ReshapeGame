using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayCredits : MonoBehaviour
{
    public Text[] textArr;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < textArr.Length; i++)
        {
           StartCoroutine(ActivateText(textArr[i], 5.0f * (float) i));
           StartCoroutine(DeActivateText(textArr[i], 5.0f * (float)i + 4.5f));
        }
        
        StartCoroutine(GoBackToMain(5.0f * (textArr.Length + 1)));
    }

    IEnumerator ActivateText(Text currentText, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        currentText.gameObject.SetActive(true);
    }
    // Update is called once per frame
    IEnumerator DeActivateText(Text currentText, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        currentText.gameObject.SetActive(false);
      
    }
    IEnumerator GoBackToMain(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        FindObjectOfType<GameManager>().MainMenu();
    }
}
