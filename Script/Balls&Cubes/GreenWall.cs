using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenWall : MonoBehaviour
{

    private bool getDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.ballsGotten.Count == 0) 
        {
            transform.tag = "wall";
        }
        else
        {
            if (Player.ballsGotten[0] != 2)
            {
                transform.tag = "wall";
            }
            else
            {
                transform.tag = "cube";
                if (getDown)
                {
                    if (transform.position.y >= -0.09f)
                    {
                        transform.Translate(Vector3.down * Time.deltaTime * 3.0f);
                    }
                    else
                    {
                        Player.ballsGotten.RemoveAt(0);
                        GameObject.Find("BallSpawner").GetComponent<BallSpawner>().RefreshBalls();
                        GameObject.Find("BallSpawner").GetComponent<BallSpawner>().SpawnBalls();
                        getDown = false;
                    }
                }
            }
        }


        
        
    }
    //private void GetDown()
    //{
    //    if (transform.position.y >= -0.09f)
    //    {
    //        transform.Translate(Vector3.down * Time.deltaTime);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CuteBird_bodyTrigger")
        {
            getDown = true;
            
        }
        
    }
}
