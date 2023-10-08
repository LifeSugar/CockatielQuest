using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    public static bool barrierDetected;

    public static bool wallDetected;

    public static bool objectDetected;

    public static bool _barrierDetected;
    public static bool _wallDetected;
    public static bool _objectDetected;

    void Start()
    {
        barrierDetected = false;
        _barrierDetected = false;
        wallDetected = false;
        _wallDetected = false;
        objectDetected = false;
        _objectDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !Player.isMoving)
        {
            barrierDetected = false;
            _barrierDetected = false;
            wallDetected = false;
            _wallDetected = false;
            objectDetected = false;
            _objectDetected = false;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            StartCoroutine(RecordCondition());

        }

        if (Input.GetKeyDown(KeyCode.D) && !Player.isMoving)
        {
            barrierDetected = false;
            _barrierDetected = false;
            wallDetected = false;
            _wallDetected = false;
            objectDetected = false;
            _objectDetected = false;
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
            StartCoroutine(RecordCondition());
        }

        if (Input.GetKeyDown(KeyCode.S) && !Player.isMoving)
        {
            barrierDetected = false;
            _barrierDetected = false;
            wallDetected = false;
            _wallDetected = false;
            objectDetected = false;
            _objectDetected = false;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            StartCoroutine(RecordCondition());
        }

        if (Input.GetKeyDown(KeyCode.A) && !Player.isMoving)
        {
            barrierDetected = false;
            _barrierDetected = false;
            wallDetected = false;
            _wallDetected = false;
            objectDetected = false;
            _objectDetected = false;
            transform.eulerAngles = new Vector3(0f, 270f, 0f);
            StartCoroutine(RecordCondition());
            
        }




        //if (!Player.isOver)
        //{
        //    wallDetected = false;
        //    objectDetected = false;
        //    barrierDetected = false;
        //}

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "barrier")
        {
            _barrierDetected = true;
            _objectDetected = true;
            //Debug.Log("trigger1 detects a barrier");
        }

        else if (other.gameObject.tag == "wall")
        {
            _wallDetected = true;
            _objectDetected = true;
            //Debug.Log("trigger1 detects a wall");
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "barrier")
        {
            _barrierDetected = false;
            _objectDetected = false;
            
        }

        if (other.gameObject.tag == "wall" || other.gameObject.tag == "cube")
        {
            _wallDetected = false;
            _objectDetected = false;
        }
    }

    private IEnumerator RecordCondition()
    {
        yield return new WaitForSeconds(0.03f);
        //Debug.Log("1111111111");
        barrierDetected = _barrierDetected;
        wallDetected = _wallDetected;
        objectDetected = _objectDetected;
        yield return new WaitForSeconds(0.04f);
        //Debug.Log("trigger1wallDetected = " + _wallDetected);
        //Debug.Log("_trigger1barrierDetected = " + _barrierDetected);
    }

    public void Forward()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    public void Right()
    {
        transform.eulerAngles = new Vector3(0f, 90f, 0f);
    }

    public void Back()
    {
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

    public void Left()
    {
        transform.eulerAngles = new Vector3(0f, 270f, 0f);
    }
}
