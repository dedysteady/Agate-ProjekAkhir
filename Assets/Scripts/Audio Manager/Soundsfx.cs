using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundsfx : MonoBehaviour
{
    public AudioClip moveSliding;
    public AudioClip moveJigsaw;
    public AudioClip victory;
    public AudioClip getReward;
    public AudioClip clickButton;
    public AudioClip spin;

    private AudioSource player;

    private void Start()
    {
        player = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SfxMuteUnMute();
    }

    public void SfxMuteUnMute()
    {
        if (PlayerPrefs.GetInt("sfx") == 1)
        {
            player.mute = true;
        }
        else
        {
            player.mute = false;
        }
    }


    public void PlaySliding()
    {
        player.PlayOneShot(moveSliding);
    }

    public void PlayJigsaw()
    {
        player.PlayOneShot(moveJigsaw);
    }

    public void PlayVictory()
    {
        player.PlayOneShot(victory);
    }

    public void PlayClick()
    {
        player.PlayOneShot(clickButton);
    }

    public void PlayGetReward()
    {
        player.PlayOneShot(getReward);
    }

    public void PlaySpin()
    {
        player.PlayOneShot(spin);
    }
}