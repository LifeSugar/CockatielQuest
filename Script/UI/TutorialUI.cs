using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
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
            StartCoroutine(Appear());
        }
        
        
    }

    private IEnumerator Appear()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<CanvasGroup>().alpha = 255f;
    }
}
