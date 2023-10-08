using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static bool flyAction;
    [SerializeField] private AudioClip getFeather;
    [SerializeField] private AudioClip getBalls;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        Player.isFlying = false;
        flyAction = false;
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "feather")
        {
            Player.isFlying = true;
            _audioSource.PlayOneShot(getFeather);

        }

        if (other.gameObject.tag == "balls")
        {
            _audioSource.PlayOneShot(getBalls);
        }

        if (other.gameObject.tag == "seed")
        {
            _audioSource.PlayOneShot(win);
        }

        

        //if (other.gameObject.name == "BlueBall Variant")
        //{
        //    Player.ballsGotten.Add(0);
        //}

        //if (other.gameObject.name == "YellowBall Variant")
        //{
        //    Player.ballsGotten.Add(1);
        //}

        //if (other.gameObject.name == "GreenBall Variant")
        //{
        //    Player.ballsGotten.Add(2);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "feather")
        {
            flyAction = true;
        }

        // if (other.gameObject.tag == "balls")
        // {
        //     _audioSource.PlayOneShot(getBalls);
        // }
    }
}
