using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]

public class MoviePlayer : MonoBehaviour {

    //=================================================================================
    // © 2016 Scott Durkin, All rights reserved.
    // By Downloading and using this script credit must 
    // be given to the creator know as "Unity3D With Scott".
    // YouTube Channel: https://www.youtube.com/channel/UC9hfBvn17qSIrdFwAk56oZg
    //=================================================================================

    public MovieTexture movie;
    private AudioSource audio;

    void Start ()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;

        movie.Play();
        audio.Play();

    }
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P) && movie.isPlaying)
        {
            movie.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.P) && !movie.isPlaying)
        {
            movie.Play();
        }
    }
}
