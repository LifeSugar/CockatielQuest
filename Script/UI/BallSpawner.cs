using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    // public Vector3 locOne = new Vector3(-8.86f, 9.17f, -7.63f);
    // public Vector3 locTwo = new Vector3(-7.97f, 9.17f, -7.63f);
    // public Vector3 locThree = new Vector3(-7.08f, 9.17f, -7.63f);
    // public Vector3 locFour = new Vector3(-6.2f, 9.17f, -7.63f);
    // public Vector3 locFive = new Vector3(-5.3f, 9.17f, -7.63f);
    //
    // public GameObject nothing;
    // public GameObject blue;
    // public GameObject yellow;
    // public GameObject green;

    public Sprite empty;
    public Sprite blueBall;
    public Sprite yellowBall;
    public Sprite greenBall;

    // private GameObject _one;
    // private GameObject _two;
    // private GameObject _three;
    // private GameObject _four;
    // private GameObject _five;
    
    public UnityEngine.UI.Image ball1;
    public UnityEngine.UI.Image ball2;
    public UnityEngine.UI.Image ball3;
    public UnityEngine.UI.Image ball4;
    public UnityEngine.UI.Image ball5;
    


    private void Start()
    {
        // ball1.GetComponent<Image>().sprite = ttt;
        // ball1.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBalls();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            RefreshBalls();
        }
    }

    public void SpawnBalls()
    {
        if (Player.ballsGotten.Count == 0)
        {
            ball1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        else if (Player.ballsGotten.Count >= 1)
        {
            Debug.Log("one!");
            if (Player.ballsGotten[0] == 0)
            {
                ball1.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                ball1.GetComponent<Image>().sprite = blueBall;
            }
            if (Player.ballsGotten[0] == 1)
            {
                ball1.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                ball1.GetComponent<Image>().sprite = yellowBall;
            }
            if (Player.ballsGotten[0] == 2)
            {
                ball1.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                ball1.GetComponent<Image>().sprite = greenBall;
            }

            if (Player.ballsGotten.Count >= 2)
            {
                Debug.Log("two");
                if (Player.ballsGotten[1] == 0)
                {
                    ball2.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    ball2.GetComponent<Image>().sprite = blueBall;
                }
                if (Player.ballsGotten[1] == 1)
                {
                    ball2.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    ball2.GetComponent<Image>().sprite = yellowBall;
                }
                if (Player.ballsGotten[1] == 2)
                {
                    ball2.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    ball2.GetComponent<Image>().sprite = greenBall;
                }

                if (Player.ballsGotten.Count >= 3)
                {
                    Debug.Log("three!");
                    if (Player.ballsGotten[2] == 0)
                    {
                        ball3.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                        ball3.GetComponent<Image>().sprite = blueBall;
                    }
                    if (Player.ballsGotten[2] == 1)
                    {
                        ball3.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                        ball3.GetComponent<Image>().sprite = yellowBall;
                    }
                    if (Player.ballsGotten[2] == 2)
                    {
                        ball3.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                        ball3.GetComponent<Image>().sprite = greenBall;
                    }

                    if (Player.ballsGotten.Count >= 4)
                    {
                        Debug.Log("four!");
                        if (Player.ballsGotten[3] == 0)
                        {
                            ball4.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                            ball4.GetComponent<Image>().sprite = blueBall;
                        }
                        if (Player.ballsGotten[3] == 1)
                        {
                            ball4.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                            ball4.GetComponent<Image>().sprite = yellowBall;
                        }
                        if (Player.ballsGotten[3] == 2)
                        {
                            ball4.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                            ball4.GetComponent<Image>().sprite = greenBall;
                        }

                        if (Player.ballsGotten.Count >= 5)
                        {
                            Debug.Log("five!");
                            if (Player.ballsGotten[4] == 0)
                            {
                                ball5.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                                ball5.GetComponent<Image>().sprite = blueBall;
                            }
                            if (Player.ballsGotten[4] == 1)
                            {
                                ball5.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                                ball5.GetComponent<Image>().sprite = yellowBall;
                            }
                            if (Player.ballsGotten[4] == 2)
                            {
                                ball5.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                                ball5.GetComponent<Image>().sprite = greenBall;
                            }
                        }
                    }
                }
            }
        }
    }
    
    public void  RefreshBalls()
    {
        // _one = Instantiate(nothing, locOne, Quaternion.identity);
        // _two = Instantiate(nothing, locOne, Quaternion.identity);
        // _three = Instantiate(nothing, locOne, Quaternion.identity);
        // _four = Instantiate(nothing, locOne, Quaternion.identity);
        // _five = Instantiate(nothing, locOne, Quaternion.identity);
        ball1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        ball2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        ball3.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        ball4.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        ball5.GetComponent<Image>().color = new Color(0, 0, 0, 0);

    }
}
