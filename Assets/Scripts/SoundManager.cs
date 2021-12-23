using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip moveSliding;
    public AudioClip moveJigsaw;
    public AudioClip gameOver;
    public AudioClip getReward;
    public AudioClip clickButton;

    private AudioSource player;

    private void Start()
    {
        player = GetComponent<AudioSource>();
    }


    public void PlaySliding()
    {
        player.PlayOneShot(moveSliding);
    }

    public void PlayJigsaw()
    {
        player.PlayOneShot(moveJigsaw);
    }

    public void PlayGameOver()
    {
        player.PlayOneShot(gameOver);
    }

    public void PlayClick()
    {
        player.PlayOneShot(clickButton);
    }

    public void PlayGetReward()
    {
        player.PlayOneShot(getReward);
    }
}