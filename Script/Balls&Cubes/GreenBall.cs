using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBall : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "barrier" || other.gameObject.tag == "Player")
        {
            
            GameObject.Find("BallSpawner").GetComponent<BallSpawner>().RefreshBalls();
            Player.ballsGotten.Add(2);
            foreach (int ballgotten in Player.ballsGotten)
            {
                Debug.Log(ballgotten);
            }
            Destroy(gameObject);
            GameObject.Find("BallSpawner").GetComponent<BallSpawner>().SpawnBalls();
            
        }
        
    }
}
