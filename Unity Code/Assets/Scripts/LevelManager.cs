using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager S;
    
    public string nextScene;

    void Awake()
    {
        if (LevelManager.S)
        {
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.S)
        {
            GameManager.S.SpawnMallow();
        }
    }

    public void NextLevel()
    {
        if (nextScene == "Start Menu" && GameManager.S)
        {
            Destroy(GameManager.S.gameObject);
        }
        GameManager.S.respawnPos = Vector3.zero;
        SceneManager.LoadScene(nextScene);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void btn_Start()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void btn_Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void btn_Back()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
