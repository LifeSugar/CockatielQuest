using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool isStart = false;
    // Start is called before the first frame update
    public void Begin()
    {
        isStart = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (isStart == true)
        {
            gameObject.SetActive(false);
        }
    }
}
