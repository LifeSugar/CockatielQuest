using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YOUWIN : MonoBehaviour
{

    private Vector2 oriPos ;

    private Vector2 targetPos = new Vector2(0f, -540f);

    private Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isWin && !Player.isLose)
        {
            // oriPos = gameObject.GetComponent<RectTransform>().anchoredPosition;
            // gameObject.GetComponent<RectTransform>().anchoredPosition =
            //     Vector2.SmoothDamp(oriPos, targetPos,ref velocity, 0.3f);
            StartCoroutine(ShowUI());

        }

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(Level0.nextLevel);
    }


    private IEnumerator ShowUI()
    {
        yield return new WaitForSeconds(0.7f);
        oriPos = gameObject.GetComponent<RectTransform>().anchoredPosition;
        gameObject.GetComponent<RectTransform>().anchoredPosition =
            Vector2.SmoothDamp(oriPos, targetPos,ref velocity, 0.3f);
    }
}
