using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Feather : MonoBehaviour
{

    private float moveSpeed = 0.1f;

    float timer = 0;

    //private IEnumerator Dispear()
    //{
    //    float elapsedTime = 0;
    //    origScale = transform.localScale;
    //    Vector3 dispear = new Vector3(0f, 0f, 0f);

    //    while (elapsedTime < smallTime)
    //    {
    //        transform.localScale = Vector3.Lerp(origScale, dispear, (elapsedTime / Time.deltaTime));
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }


    private bool _ready;
    public static bool again;

    void Start()
    {
        _ready = false;
        again = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player.isFlying && _ready)
        {

            timer += Time.fixedDeltaTime;
            if (timer > 0.2f)
            {
                transform.Rotate(Vector3.up, 720 * Time.fixedDeltaTime, Space.Self);
                if (timer < 0.5f)
                {
                    transform.position = transform.position + new Vector3(0, moveSpeed, 0);
                }
            }

            if (timer > 0.7f)
            {
                Destroy(gameObject);
            }


        }

        else
        {
            transform.Rotate(Vector3.up, 45 * Time.fixedDeltaTime, Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _ready = true;
            if (Player.isFlying == true)
            {
                again = true;
            } 
        }
    }


}    
        