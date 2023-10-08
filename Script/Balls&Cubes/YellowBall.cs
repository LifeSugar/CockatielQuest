using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBall : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "barrier" || other.gameObject.tag == "Player")
        {
 
            GameObject.Find("BallSpawner").GetComponent<BallSpawner>().RefreshBalls();
            
            Player.ballsGotten.Add(1);
            Destroy(gameObject);
            foreach (int ballgotten in Player.ballsGotten)
            {
                Debug.Log(ballgotten);
            }
            
            GameObject.Find("BallSpawner").GetComponent<BallSpawner>().SpawnBalls();
        }
    }
}
