using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level0_5 : MonoBehaviour
{
    private string nextLevel = "Level-1";
    // Start is called before the first frame update
    void Start()
    {
        nextLevel = "Level-1";
        Player.ballsGotten = new List<int> { };
        Player.stepLimit = 6;
        GameObject.Find("BallSpawner").GetComponent<BallSpawner>().SpawnBalls();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Player.stepLimit < 0)
        {
            Player.isLose = true;
        }
    }
    
    
    public void Quit()
    {
        Application.Quit();
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}