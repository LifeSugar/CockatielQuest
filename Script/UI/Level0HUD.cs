using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0HUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.isStart == true)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 255f;
        }
    }
}
