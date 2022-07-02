using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState {playing, oops}

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public GameState gameState;

    public Text scoreOverlay;

    public GameObject mallowPrefab;
    private GameObject mallow;

    public Vector3 respawnPos;

    private int score = 0;
    private int totalDeaths = 0;

    void Awake()
    {
        if (GameManager.S)
        {
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
        }

        DontDestroyOnLoad(this);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.playing;

        scoreOverlay.text = "Score: " + score + "\nDeaths: " + totalDeaths;
        scoreOverlay.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoreOverlay.text = "Score: " + score + "\nDeaths: " + totalDeaths;
    }

    public int GetDeaths()
    {
        return totalDeaths;
    }

    public void AddDeath(int value)
    {
        totalDeaths += value;
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void Respawn()
    {
        StartCoroutine(Respawn_IEnum());
    }

    public IEnumerator Respawn_IEnum()
    {
        gameState = GameState.oops;

        yield return new WaitForSeconds(3.0f);

        gameState = GameState.playing;

        yield return new WaitForSeconds(0.5f);

        SpawnMallow();
    }

    public void SetRespawn(Vector3 location)
    {
        respawnPos = location;
    }

    public GameObject GetMallow()
    {
        return mallow;
    }

    public void SpawnMallow()
    {
        if (!mallow)
        {
            mallow = Instantiate(mallowPrefab, respawnPos, Quaternion.identity);
        }
    }
}
