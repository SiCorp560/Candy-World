using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager S;

    private AudioSource audio;

    public AudioClip jumpClip;
    public AudioClip tokenClip;
    public AudioClip lifeClip;
    public AudioClip mallowDeathClip;
    
    void Awake()
    {
        if (SoundManager.S)
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
        audio = GetComponent<AudioSource>();
    }

    public void JumpSound()
    {
        audio.PlayOneShot(jumpClip);
    }

    public void TokenSound()
    {
        audio.PlayOneShot(tokenClip);
    }

    public void LifeSound()
    {
        audio.PlayOneShot(lifeClip);
    }

    public void MallowDeathSound()
    {
        audio.PlayOneShot(mallowDeathClip);
    }
}
