/* * (Jerod Lockhart) 
 * * (Random Music picker) 
 * * (Team Project 1) 
 * * (This makes the music random between levels) 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusicPicker : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            source.clip = getRandomClip();
            source.Play();
        }
    }

    private AudioClip getRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}
