using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YOULOSE : MonoBehaviour
{
    private Vector2 oriPos ;

    private Vector2 targetPos = new Vector2(0f, -540f);

    private Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Player.isLose && !Player.isWin)
        {
            // oriPos = gameObject.GetComponent<RectTransform>().anchoredPosition;
            // gameObject.GetComponent<RectTransform>().anchoredPosition =
            //     Vector2.SmoothDamp(oriPos, targetPos,ref velocity, 0.3f);
            ShowUI();
            
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShowUI()
    {
        oriPos = gameObject.GetComponent<RectTransform>().anchoredPosition;
        gameObject.GetComponent<RectTransform>().anchoredPosition =
            Vector2.SmoothDamp(oriPos, targetPos,ref velocity, 0.3f);
    }
}
