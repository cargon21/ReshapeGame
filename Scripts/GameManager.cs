using System.Diagnostics;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void Play()
    {
        SetAttemptsToOne();
        SceneManager.LoadScene("LevelSelection");
    }

    public void LoadLeve0()
    {
        FindObjectOfType<DontDestroyAudio>().DestroyAudio();
        SceneManager.LoadScene("Level0");
    }

    public void LoadLeve1()
    {
        FindObjectOfType<DontDestroyAudio>().DestroyAudio();
        SceneManager.LoadScene("Level1");
    }

    public void LoadLeve2()
    {
        FindObjectOfType<DontDestroyAudio>().DestroyAudio();
        SceneManager.LoadScene("Level2");
    }

    public void LoadLeve3()
    {
        FindObjectOfType<DontDestroyAudio>().DestroyAudio();
        SceneManager.LoadScene("Level3");
    }

    public void LoadLeve4()
    {
        FindObjectOfType<DontDestroyAudio>().DestroyAudio();
        SceneManager.LoadScene("Level4");
    }

    public void LoadLeve5()
    {
        FindObjectOfType<DontDestroyAudio>().DestroyAudio();
        SceneManager.LoadScene("Level5");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelComplete()
    {
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            SceneManager.LoadScene("Credits");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(GameObject.Find("CheckpointMaster"));
   
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }

    public void SetAttemptsToOne()
    {
        PlayerMovement.attemptsNum = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("CheckpointMaster"));
    }
}
