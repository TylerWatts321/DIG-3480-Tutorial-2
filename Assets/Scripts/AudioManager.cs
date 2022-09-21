using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip mainMusic;

    public AudioClip loseSound;

    public AudioClip winSound;

    public AudioSource musicSource;

    Animator anim;

    public static AudioManager instance;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        musicSource.clip = mainMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayWinMusic()
    {
        musicSource.Stop();
        musicSource.clip = winSound;
        musicSource.loop = false;
        musicSource.Play();
    }

    public void PlayLoseMusic()
    {
        musicSource.Stop();
        musicSource.clip = loseSound;
        musicSource.loop = false;
        musicSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
            //musicSource.clip = musicClipOne;
            //musicSource.Play();

        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    musicSource.Stop();
        //    anim.SetInteger("State", 0);
        //}

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    musicSource.clip = musicClipTwo;
        //    musicSource.Play();
        //    anim.SetInteger("State", 2);
        //}

        //if (Input.GetKeyUp(KeyCode.R))
        //{
        //    musicSource.Stop();
        //    anim.SetInteger("State", 0);
        //}

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    musicSource.loop = true;
        //}

        //if (Input.GetKeyUp(KeyCode.L))
        //{
        //    musicSource.loop = false;
        //}
    }
}
