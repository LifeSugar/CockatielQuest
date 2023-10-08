using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 origPos;

    private Vector3 targetPos;

    private Vector3 oriAngle;

    private Vector3 targetAngle;

    private float timeToMove = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.isStart == true)
        {
            StartCoroutine(MoveCam());
        }
    }

    private IEnumerator MoveCam()
    {
        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = new Vector3(-14.67f, 52f, -30.52f);

        oriAngle = transform.eulerAngles;
        targetAngle = new Vector3(60f, 0f, 0f);
        
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            transform.eulerAngles = Vector3.Lerp(oriAngle, targetAngle, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        transform.eulerAngles = targetAngle;

    }

    public void Move()
    {
        StartCoroutine(MoveCam());
    }
}
