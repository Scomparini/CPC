using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip destructionClip;
    public AudioClip scoreClip;
    public AudioClip swipeClip;

    public void PlaySwipe()
    {
        audioSource.PlayOneShot(swipeClip);
    }

    public void PlayScore()
    {
        audioSource.PlayOneShot(scoreClip);
    }

    public void PlayDestruction()
    {
        audioSource.PlayOneShot(destructionClip);
    }
}
